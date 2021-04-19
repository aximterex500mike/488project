using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class test1
    {
        // A Test behaves as an ordinary method
        [Test]
        public void test1SimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator movement()
        {
            GameObject cowboy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cowboy"));
            GameObject cactus = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/BadCactus"));
            GameObject coffin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Coffin"));

            //get intial positions
            float coffinposy = coffin.transform.position.y;
            float coffinposx = coffin.transform.position.x;
            float cactusposy = cactus.transform.position.y;
            float cactusposx = cactus.transform.position.x;
            float cowboyposy = cowboy.transform.position.y;
            float cowboyposx = cowboy.transform.position.x;

            //move cowboy
            cowboy.transform.position = new Vector2(cowboy.transform.position.x + 4, cowboy.transform.position.y + 4);
            yield return new WaitForSeconds(0.1f);

            //assert cactus does not move at this distance and coffin does
            Assert.Equals(cactus.transform.position.y, cactusposy);
            Assert.Equals(cactus.transform.position.x, cactusposx);
            Assert.Greater(coffin.transform.position.y, coffinposy);
            Assert.Greater(coffin.transform.position.x, coffinposx);

            //cactus should now move 
            cowboy.transform.position = new Vector2(cowboy.transform.position.x + 3, cowboy.transform.position.y + 3);
            Assert.Greater(cactus.transform.position.y, cactusposy);
            Assert.Greater(cactus.transform.position.x, cactusposx);
            yield return null;
        }

        [UnityTest]
        public IEnumerator playerdamage()
        {
            GameObject cowboy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cowboy"));
            int hp = cowboy.GetComponent<Health>().hp;
            GameObject coffin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/testBullet"));
            yield return new WaitForSeconds(0.1f);
            Assert.Less(hp, cowboy.GetComponent<Health>().hp);
        }
        [UnityTest]
        public IEnumerator enemydamageandkill()
        {
            GameObject control = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameController"));
            GameObject coffin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Coffin"));
            int goal = control.GetComponent<LevelController>().goal;
            int hp = coffin.GetComponent<Health>().hp;
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));

            //enemy should have taken damage and have less hp
            Assert.Less(hp, coffin.GetComponent<Health>().hp);
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SBullet"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SBullet"));
            yield return new WaitForSeconds(0.1f);

            //enemy should have died and reduced goal
            Assert.Less(control.GetComponent<LevelController>().goal, goal);
            yield return null;
        }
    }
}
