using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ProjectScript;

namespace Tests
{
    public class Parse
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ParseSimplePasses()
        {
            ProgramParser parser = new ProgramParser();
            List<ProgramUnit> programUnits = new List<ProgramUnit>
            {
                new AIIf(), new AIPlayer(), new AIValueProperty(ValuePropertyType.Health, AIOperator.LessEqual, 50),
                new AIThen(), new MoveTowards(), new AIPlayer(),
                new AIEnd(),
            };

            List<List<List<List<int>>>> program = parser.parse(programUnits);
            Assert.AreEqual(parser.errorType, AIErrorType.NoError);
            Assert.AreEqual(program.Count, 1);
            Assert.AreEqual(program[0].Count, 2);
            Assert.AreEqual(program[0][0], new List<List<int>>{
                new List<int> { (int)PhraseType.Keyword, (int)KeywordType.Condition,},
                new List<int> { (int)PhraseType.Noun, (int)NounType.Player, (int)RelativeSide.Friend, 0,},
                new List<int> { (int)PhraseType.Adjective, (int)AdjType.ValueProperty, (int)ValuePropertyType.Health, (int)AIOperator.LessEqual, 50,},
            });
            Assert.AreEqual(program[0][1], new List<List<int>> {
                new List<int> { (int)PhraseType.Keyword, (int)KeywordType.Action,},
                new List<int> { (int)PhraseType.Verb, (int)ActionType.MoveTowards,},
                new List<int> { (int)PhraseType.Noun, (int)NounType.Player, (int)RelativeSide.Friend, 0,},
            });
            // Use the Assert class to test conditions
        }

        // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // // `yield return null;` to skip a frame.
        // [UnityTest]
        // public IEnumerator ParseWithEnumeratorPasses()
        // {
        //     // Use the Assert class to test conditions.
        //     // Use yield to skip a frame.
        //     yield return null;
        // }
    }
}
