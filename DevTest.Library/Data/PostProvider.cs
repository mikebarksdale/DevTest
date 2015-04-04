using DevTest.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTest.Library.Extensions;

namespace DevTest.Library.Data
{
    /// <summary>
    /// Provides posts. Do not modify this class.
    /// </summary>
    public static class PostProvider
    {
        /// <summary>
        /// Returns an enumerable of PostModels. Posts and comments and randomly generated.
        /// </summary>
        /// <returns>An enumerable of PostModels.</returns>
        public static IEnumerable<PostModel> GetPosts()
        {
            var persons = GetPersons().ToList();
            persons.Randomize();

            var randomNumberGenerator = new Random();

            var comments = GetCommentContent().ToList();

            var posts = GetPostContent().Select(p => new PostModel
            {
                Content = p,
                PersonPostedId = persons[randomNumberGenerator.Next(0, persons.Count)].Id,
                PersonsLiked = persons.OrderBy(r => randomNumberGenerator.NextDouble()).Take(randomNumberGenerator.Next(1, persons.Count + 1)).Select(i => i.Id).ToList(),
                Comments = persons.OrderBy(r => randomNumberGenerator.NextDouble()).Take(randomNumberGenerator.Next(1, 4)).Select(c => new CommentModel
                {
                    Comment = comments[randomNumberGenerator.Next(0, comments.Count)],
                    PersonId = persons[randomNumberGenerator.Next(0, persons.Count)].Id
                }).ToList()
            });

            return posts;
        }

        #region Private Methods
        /// <summary>
        /// Provides a default list of persons.
        /// </summary>
        /// <returns>An enumerable of PersonModels.</returns>
        private static IEnumerable<PersonModel> GetPersons()
        {
            return new List<PersonModel>
            {
                new PersonModel { UserName = "sasha", BirthDate = new DateTime(1982, 1, 3) },
                new PersonModel { UserName = "jeff", BirthDate = new DateTime(2000, 4, 18) },
                new PersonModel { UserName = "steve", BirthDate = new DateTime(1996, 6, 13) },
                new PersonModel { UserName = "lora", BirthDate = new DateTime(1987, 8, 28) },
                new PersonModel { UserName = "brittany", BirthDate = new DateTime(1989, 2, 4) },
                new PersonModel { UserName = "alex", BirthDate = new DateTime(1962, 11, 1) },
                new PersonModel { UserName = "jeremy", BirthDate = new DateTime(1931, 4, 22) },
                new PersonModel { UserName = "eric", BirthDate = new DateTime(1965, 4, 19) },
                new PersonModel { UserName = "amber", BirthDate = new DateTime(1999, 12, 7) },
                new PersonModel { UserName = "glenn", BirthDate = new DateTime(1975, 3, 11) },
                new PersonModel { UserName = "tony", BirthDate = new DateTime(1946, 7, 12) },
                new PersonModel { UserName = "sue", BirthDate = new DateTime(1992, 2, 8) },
                new PersonModel { UserName = "susan", BirthDate = new DateTime(2001, 8, 7) },
                new PersonModel { UserName = "monica", BirthDate = new DateTime(1995, 5, 29) },
            };
        }

        /// <summary>
        /// Generates a list of 20 to 30 "posts".
        /// </summary>
        /// <returns>An enumerable of 20 to 30, numbered strings.</returns>
        private static IEnumerable<string> GetPostContent()
        {
            var postCount = new Random().Next(20, 31);

            for (int x = 0; x < postCount; x++)
                yield return string.Format("post{0}", x + 1);
        }

        /// <summary>
        /// Returns a list of comments.
        /// </summary>
        /// <returns>An enumerable of comments.</returns>
        private static IEnumerable<string> GetCommentContent()
        {
            yield return @"Life is about making an impact, not making an income. –Kevin Kruse";
            yield return @"Whatever the mind of man can conceive and believe, it can achieve. –Napoleon Hill";
            yield return @"Strive not to be a success, but rather to be of value. –Albert Einstein";
            yield return @"Two roads diverged in a wood, and I—I took the one less traveled by, And that has made all the difference.  –Robert Frost";
            yield return @"I attribute my success to this: I never gave or took any excuse. –Florence Nightingale";
            yield return @"You miss 100% of the shots you don’t take. –Wayne Gretzky";
            yield return @"I’ve missed more than 9000 shots in my career. I’ve lost almost 300 games. 26 times I’ve been trusted to take the game winning shot and missed. I’ve failed over and over and over again in my life. And that is why I succeed. –Michael Jordan";
            yield return @"The most difficult thing is the decision to act, the rest is merely tenacity. –Amelia Earhart";
            yield return @"Every strike brings me closer to the next home run. –Babe Ruth";
            yield return @"Definiteness of purpose is the starting point of all achievement. –W. Clement Stone";
            yield return @"Life isn’t about getting and having, it’s about giving and being. –Kevin Kruse";
            yield return @"Life is what happens to you while you’re busy making other plans. –John Lennon";
            yield return @"We become what we think about. –Earl Nightingale";
            yield return @"Twenty years from now you will be more disappointed by the things that you didn’t do than by the ones you did do, so throw off the bowlines, sail away from safe harbor, catch the trade winds in your sails.  Explore, Dream, Discover. –Mark Twain";
            yield return @"Life is 10% what happens to me and 90% of how I react to it. –Charles Swindoll";
            yield return @"The most common way people give up their power is by thinking they don’t have any. –Alice Walker";
            yield return @"The mind is everything. What you think you become.  –Buddha";
            yield return @"The best time to plant a tree was 20 years ago. The second best time is now. –Chinese Proverb";
            yield return @"An unexamined life is not worth living. –Socrates";
            yield return @"Eighty percent of success is showing up. –Woody Allen";
            yield return @"Your time is limited, so don’t waste it living someone else’s life. –Steve Jobs";
            yield return @"Winning isn’t everything, but wanting to win is. –Vince Lombardi";
            yield return @"I am not a product of my circumstances. I am a product of my decisions. –Stephen Covey";
            yield return @"Every child is an artist.  The problem is how to remain an artist once he grows up. –Pablo Picasso";
            yield return @"You can never cross the ocean until you have the courage to lose sight of the shore. –Christopher Columbus";
            yield return @"I’ve learned that people will forget what you said, people will forget what you did, but people will never forget how you made them feel. –Maya Angelou";
            yield return @"Either you run the day, or the day runs you. –Jim Rohn";
            yield return @"Whether you think you can or you think you can’t, you’re right. –Henry Ford";
            yield return @"The two most important days in your life are the day you are born and the day you find out why. –Mark Twain";
            yield return @"Whatever you can do, or dream you can, begin it.  Boldness has genius, power and magic in it. –Johann Wolfgang von Goethe";
            yield return @"The best revenge is massive success. –Frank Sinatra";
            yield return @"People often say that motivation doesn’t last. Well, neither does bathing.  That’s why we recommend it daily. –Zig Ziglar";
            yield return @"Life shrinks or expands in proportion to one’s courage. –Anais Nin";
            yield return @"If you hear a voice within you say “you cannot paint,” then by all means paint and that voice will be silenced. –Vincent Van Gogh";
            yield return @"There is only one way to avoid criticism: do nothing, say nothing, and be nothing. –Aristotle";
            yield return @"Ask and it will be given to you; search, and you will find; knock and the door will be opened for you. –Jesus";
            yield return @"The only person you are destined to become is the person you decide to be. –Ralph Waldo Emerson";
            yield return @"Go confidently in the direction of your dreams.  Live the life you have imagined. –Henry David Thoreau";
            yield return @"When I stand before God at the end of my life, I would hope that I would not have a single bit of talent left and could say, I used everything you gave me. –Erma Bombeck";
            yield return @"Few things can help an individual more than to place responsibility on him, and to let him know that you trust him.  –Booker T. Washington";
            yield return @"Certain things catch your eye, but pursue only those that capture the heart. – Ancient Indian Proverb";
            yield return @"Believe you can and you’re halfway there. –Theodore Roosevelt";
            yield return @"Everything you’ve ever wanted is on the other side of fear. –George Addair";
            yield return @"We can easily forgive a child who is afraid of the dark; the real tragedy of life is when men are afraid of the light. –Plato";
            yield return @"Teach thy tongue to say, “I do not know,” and thous shalt progress. –Maimonides";
            yield return @"Start where you are. Use what you have.  Do what you can. –Arthur Ashe";
            yield return @"When I was 5 years old, my mother always told me that happiness was the key to life.  When I went to school, they asked me what I wanted to be when I grew up.  I wrote down ‘happy’.  They told me I didn’t understand the assignment, and I told them they didn’t understand life. –John Lennon";
            yield return @"Fall seven times and stand up eight. –Japanese Proverb";
            yield return @"When one door of happiness closes, another opens, but often we look so long at the closed door that we do not see the one that has been opened for us. –Helen Keller";
            yield return @"Everything has beauty, but not everyone can see. –Confucius";
            yield return @"How wonderful it is that nobody need wait a single moment before starting to improve the world. –Anne Frank";
            yield return @"When I let go of what I am, I become what I might be. –Lao Tzu";
            yield return @"Life is not measured by the number of breaths we take, but by the moments that take our breath away. –Maya Angelou";
            yield return @"Happiness is not something readymade.  It comes from your own actions. –Dalai Lama";
            yield return @"If you’re offered a seat on a rocket ship, don’t ask what seat! Just get on. –Sheryl Sandberg";
            yield return @"First, have a definite, clear practical ideal; a goal, an objective. Second, have the necessary means to achieve your ends; wisdom, money, materials, and methods. Third, adjust all your means to that end. –Aristotle";
            yield return @"If the wind will not serve, take to the oars. –Latin Proverb";
            yield return @"You can’t fall if you don’t climb.  But there’s no joy in living your whole life on the ground. –Unknown";
            yield return @"We must believe that we are gifted for something, and that this thing, at whatever cost, must be attained. –Marie Curie";
            yield return @"Too many of us are not living our dreams because we are living our fears. –Les Brown";
            yield return @"Challenges are what make life interesting and overcoming them is what makes life meaningful. –Joshua J. Marine";
            yield return @"If you want to lift yourself up, lift up someone else. –Booker T. Washington";
            yield return @"I have been impressed with the urgency of doing. Knowing is not enough; we must apply. Being willing is not enough; we must do. –Leonardo da Vinci";
            yield return @"Limitations live only in our minds.  But if we use our imaginations, our possibilities become limitless. –Jamie Paolinetti";
            yield return @"You take your life in your own hands, and what happens? A terrible thing, no one to blame. –Erica Jong";
            yield return @"What’s money? A man is a success if he gets up in the morning and goes to bed at night and in between does what he wants to do. –Bob Dylan";
            yield return @"I didn’t fail the test. I just found 100 ways to do it wrong. –Benjamin Franklin";
            yield return @"In order to succeed, your desire for success should be greater than your fear of failure. –Bill Cosby";
            yield return @"A person who never made a mistake never tried anything new. – Albert Einstein";
            yield return @"The person who says it cannot be done should not interrupt the person who is doing it. –Chinese Proverb";
            yield return @"There are no traffic jams along the extra mile. –Roger Staubach";
            yield return @"It is never too late to be what you might have been. –George Eliot";
            yield return @"You become what you believe. –Oprah Winfrey";
            yield return @"I would rather die of passion than of boredom. –Vincent van Gogh";
            yield return @"A truly rich man is one whose children run into his arms when his hands are empty. –Unknown";
            yield return @"It is not what you do for your children, but what you have taught them to do for themselves, that will make them successful human beings.  –Ann Landers";
            yield return @"If you want your children to turn out well, spend twice as much time with them, and half as much money. –Abigail Van Buren";
            yield return @"Build your own dreams, or someone else will hire you to build theirs. –Farrah Gray";
            yield return @"The battles that count aren’t the ones for gold medals. The struggles within yourself–the invisible battles inside all of us–that’s where it’s at. –Jesse Owens";
            yield return @"Education costs money.  But then so does ignorance. –Sir Claus Moser";
            yield return @"I have learned over the years that when one’s mind is made up, this diminishes fear. –Rosa Parks";
            yield return @"It does not matter how slowly you go as long as you do not stop. –Confucius";
            yield return @"If you look at what you have in life, you’ll always have more. If you look at what you don’t have in life, you’ll never have enough. –Oprah Winfrey";
            yield return @"Remember that not getting what you want is sometimes a wonderful stroke of luck. –Dalai Lama";
            yield return @"You can’t use up creativity.  The more you use, the more you have. –Maya Angelou";
            yield return @"Dream big and dare to fail. –Norman Vaughan";
            yield return @"Our lives begin to end the day we become silent about things that matter. –Martin Luther King Jr.";
            yield return @"Do what you can, where you are, with what you have. –Teddy Roosevelt";
            yield return @"If you do what you’ve always done, you’ll get what you’ve always gotten. –Tony Robbins";
            yield return @"Dreaming, after all, is a form of planning. –Gloria Steinem";
            yield return @"It’s your place in the world; it’s your life. Go on and do all you can with it, and make it the life you want to live. –Mae Jemison";
            yield return @"You may be disappointed if you fail, but you are doomed if you don’t try. –Beverly Sills";
            yield return @"Remember no one can make you feel inferior without your consent. –Eleanor Roosevelt";
            yield return @"Life is what we make it, always has been, always will be. –Grandma Moses";
            yield return @"The question isn’t who is going to let me; it’s who is going to stop me. –Ayn Rand";
            yield return @"When everything seems to be going against you, remember that the airplane takes off against the wind, not with it. –Henry Ford";
            yield return @"It’s not the years in your life that count. It’s the life in your years. –Abraham Lincoln";
            yield return @"Change your thoughts and you change your world. –Norman Vincent Peale";
            yield return @"Either write something worth reading or do something worth writing. –Benjamin Franklin";
            yield return @"Nothing is impossible, the word itself says, “I’m possible!” –Audrey Hepburn";
            yield return @"The only way to do great work is to love what you do. –Steve Jobs";
            yield return @"If you can dream it, you can achieve it. –Zig Ziglar";
        }
        #endregion
    }
}
