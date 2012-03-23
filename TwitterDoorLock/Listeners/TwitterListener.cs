using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twitterizer;
using Twitterizer.Streaming;
using Twitterizer2.Streaming;
using System.Threading;

namespace TwitterDoorLock.Listeners
{
    class TwitterListener : IListener
    {
        public event AuthorizedUnlockEvent OnUnlock;

        public string ServiceName
        {
            get
            {
                return "Twitter";
            }
        }

        public Image ServiceIcon
        {
            get
            {
                return TwitterDoorLock.Properties.Resources.Um___;
            }
        }

        private const string AccessToken        = "458134306-Jce2w7Onw4SCqXzWPfmIp03o2vtlYaRndGWjkvGf";
        private const string AccessTokenSecret  = "Iu4lAiO7fRnrm76ZePVgwe2he9o8GGxHtNd2kUwAk";
        private const string ConsumerKey        = "jI7buSSeEFKM13boUGF0g";
        private const string ConsumerSecret     = "cCS3O40iO53rTMMc42aDNrhBw9zxdflu1EHmJWo";
        private const string TwitterUsername    = "srnddoor";

        private readonly string[] OpenCommands = new string[] { "OPEN", "UNLOCK" };

        private readonly string[] OpenResponses = new string[]{
            "Happy to oblige",
            "k :3",
            "Ohey! Sounds good!",
            "Good to see you again!",
            "Welcome back!", "Opening up",
            "You're a good person. You know that, right?",
            "Aren't you excited to be here?!",
            "Listen for the click!",
            "INSPIRE. CREATE. LEARN. UNLOCK DOORS OVER TWITTER.",
            "Door unlocked!",
            "Done!",
            "door_unlocks++;",
            "k, it's unlocked for 20 seconds-ish.",
            "Should be open now.",
            "Get inside! Quick! Before it locks again!",
            "Sounds good",
            "Should be working for you"};

        private readonly string[] UnauthorizedResponses = new string[]{
            "I'm sorry, who were you again?",
            "I'm sorry Dave, I'm afraid I can't do that.",
            "Nope.",
            "NO LEARNING FOR YOU",
            "You shouldn't actually be able to read this status, anyway, but: I can't unlock for you.",
            "ACCESS DENIED",
            "You've not enough minerals.",
            "You require more vespene gas.",
            "Not enough energy.",
            "You must construct additional pylons."
        };

        private readonly string[] UnknownCommandResponses = new string[]{
            "Wut?",
            "You're speaking in an accent that is beyond my range of hearing",
            "Wassit?",
            "I do not understand",
            "I heard my name?",
            "OIC.",
            "ashkdhaiuhdibjhsbdjahsbd"
        };

        private Random Fish = new Random();

        private readonly OAuthTokens Tokens;

        private TwitterResponse<UserIdCollection> Followers;
        private Thread UpdateFollowersThread;
        private void UpdateFollowers()
        {
            while (true)
            {
                try
                {

                    TwitterResponse<UserIdCollection> _followers = TwitterFriendship.FollowersIds(Tokens);

                    if (_followers.Result == RequestResult.Success)
                    {
                        Followers = _followers;
                    }
                    else
                    {
                        MainForm.Instance.logControl.Add("Followers update failed: " + _followers.ErrorMessage, LogEntryType.Error);
                    }
                }
                catch (Exception ex)
                {
                    MainForm.Instance.logControl.Add("Followers update failed: " + ex.Message, LogEntryType.Error);
                }

                Thread.Sleep(60000);
            }
        }

        public TwitterListener()
        {
            Tokens = new OAuthTokens();
            Tokens.AccessToken = AccessToken;
            Tokens.AccessTokenSecret = AccessTokenSecret;
            Tokens.ConsumerKey = ConsumerKey;
            Tokens.ConsumerSecret = ConsumerSecret;

            UpdateFollowersThread = new Thread(new ThreadStart(UpdateFollowers));
            UpdateFollowersThread.IsBackground = true;
            UpdateFollowersThread.Start();


            StartStreamListener();

        }

        private void ProcessNewStatus(TwitterStatus status)
        {
            // First, make sure this isn't a status we published, or one which isn't directed at us:
            if (status.User.ScreenName == TwitterUsername || status.InReplyToScreenName != TwitterUsername)
            {
                return;
            }

            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = status.Id;
            options.Latitude = 47.6231005;
            options.Longitude = -122.1645082;

            string response = "@" + status.User.ScreenName + " ";

            // Next, see if they're authorized:
            if (Followers != null && !Followers.ResponseObject.Contains(status.User.Id))
            {
                response += UnauthorizedResponses.OrderBy(x => Fish.Next()).ElementAt(0);
                return;
            }else{
                // Next, figure out what sort of command we're looking at:
                var searchString = status.Text.ToUpper();
                if (OpenCommands.Any(s => searchString.Contains(s)))
                {
                    // Everything looks good!


                    // Send the OK to unlock the door:
                    if (OnUnlock != null)
                    {
                        OnUnlock(ServiceName, status.User.ScreenName);
                    }

                    // Update the status:
                    response += OpenResponses.OrderBy(x => Fish.Next()).ElementAt(0);
                }
                else
                {
                    // We don't know that command:
                    response += UnknownCommandResponses.OrderBy(x => Fish.Next()).ElementAt(0);
                }
            }

            response += " Also, here's a random integer: " + Fish.Next(int.MinValue, int.MaxValue);

            var resp = TwitterStatus.Update(Tokens, response, options);
            if (resp.Result != RequestResult.Success)
            {
                MainForm.Instance.logControl.Add("Error posting tweet: " + resp.ErrorMessage, LogEntryType.Error);
            }
        }

        private void StartStreamListener()
        {
            // Starts listening on the Twitter streaming API
            StreamOptions options = new StreamOptions();
            TwitterStream stream = new TwitterStream(Tokens, "StudentRND Twitter Door Lock 2.0 (THE DOOOOOOOOOR)", options);
            

            stream.StartUserStream(null, new StreamStoppedCallback(delegate(StopReasons ex)
            {
                // Sometimes the Twitter streaming API will kill the stream

                // Log the failure:
                MainForm.Instance.logControl.Add("Twitter stream stopped: " + ex.ToString(), LogEntryType.Error);
                Thread.Sleep(5000);

                // Restart the stream
                StartStreamListener();
            }), new StatusCreatedCallback(ProcessNewStatus), null, null, null, null, null);
        }
    }
}
