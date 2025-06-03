using Examples.SocialMedia.Domain;
using User = Examples.SocialMedia.Infrastructure.Write.User;

namespace Examples.SocialMedia.Spec;

public class ObjectProvider
{
    private const uint
        Arthur = 100,
        Bedemir = 101,
        Villager1 = 111,
        Villager2 = 222,
        Villager3 = 333,
        Witch = 400;

    public static IEnumerable<Message> GetMessages()
    {
        uint id = 1000;

        yield return From(null, Villager1, "We have found a witch! Might we burn her?");
        yield return From(1001, Bedemir, "How do you know she is a witch?");
        yield return From(1002, Villager2, "She looks like one.");
        yield return From(null, Bedemir, "Bring her forward.");
        yield return From(null, Witch, "I'm not a witch. I'm not a witch.");
        yield return From(1005, Bedemir, "But you are dressed as one.");
        yield return From(1006, Witch, "They dressed me up like this.");
        yield return From(1006, Witch, "And this isn't my nose - it's a false one.");
        yield return From(null, Bedemir, "Well?");
        yield return From(1009, Villager1, "Well, we did do the nose.");
        yield return From(1010, Bedemir, "The nose?");
        yield return From(1011, Villager1, "And the hat. But she is a witch!");
        yield return From(1012, Bedemir, "Did you dress her up like this?");
        yield return From(1013, Villager1, "No. No. No. Yes. Yes. A bit. A bit.");
        yield return From(1013, Villager2, "No. No. No. Yes. A bit.");
        yield return From(1013, Villager1, "She has got a wart.");
        yield return From(null, Bedemir, "What makes you think she is a witch?");
        yield return From(1017, Villager3, "Well, she turned me into a newt.");
        yield return From(1018, Bedemir, "A newt?");
        yield return From(1019, Villager3, "I got better.");
        yield return From(1020, Villager2, "Burn her anyway!");
        yield return From(null, Bedemir, "Quiet! There are ways of telling whether she is a witch.");
        yield return From(1022, Villager1, "Are there? What are they? Tell us!");
        yield return From(1022, Villager2, "Do they hurt?");
        yield return From(null, Bedemir, "Tell me, what do you do with witches?");
        yield return From(1025, Villager1, "Burn them!");
        yield return From(1025, Villager2, "Burn them!");
        yield return From(1025, Villager3, "Burn them!");
        yield return From(null, Bedemir, "And what do you burn apart from witches?");
        yield return From(1029, Villager1, "More witches!");
        yield return From(1029, Villager2, "Wood!");
        yield return From(null, Bedemir, "So, why do witches burn?");
        yield return From(1032, Villager3, "Because they're made of wood?");
        yield return From(1033, Bedemir, "Good!");
        yield return From(null, Bedemir, "So, how do we tell whether she is made of wood?");
        yield return From(1035, Villager1, "Build a bridge out of her.");
        yield return From(1036, Bedemir, "Ah, but can you not also make bridges out of stone?");
        yield return From(1037, Villager1, "Oh, yeah.");
        yield return From(null, Bedemir, "Does wood sink in water?");
        yield return From(1039, Villager1, "No. No.");
        yield return From(1039, Villager2, "No. It floats. It floats!");
        yield return From(1039, Villager1, "Throw her into the pond!");
        yield return From(null, Bedemir, "What also floats in water?");
        yield return From(1043, Villager1, "Bread!");
        yield return From(1043, Villager2, "Apples!");
        yield return From(1043, Villager3, "Very small rocks!");
        yield return From(1043, Villager1, "Cider!");
        yield return From(1043, Villager2, "Gravy!");
        yield return From(1043, Villager1, "Cherries!");
        yield return From(1043, Villager2, "Mud!");
        yield return From(1043, Villager3, "Churches!");
        yield return From(1043, Villager2, "Lead. Lead!");
        yield return From(1043, Arthur, "A duck!");
        yield return From(1053, Bedemir, "Exactly!");
        yield return From(null, Bedemir, "So, logically...");
        yield return From(1055, Villager1, "If she weighs the same as a duck, she's made of wood.");
        yield return From(1056, Bedemir, "And therefore?");
        yield return From(1057, Villager2, "A witch!");
        yield break;

        Message From(MessageId? parentId, UserId userId, string text) =>
            new(++id, 2000, userId, text, DateTime.Now, parentId);
    }

    public static IEnumerable<User> GetUsers()
    {
        yield return new(Arthur, "Arthur");
        yield return new(Bedemir, "Bedemir");
        yield return new(Villager1, "Villager1");
        yield return new(Villager2, "Villager2");
        yield return new(Villager3, "Villager3");
        yield return new(Witch, "Witch");
    }
}
