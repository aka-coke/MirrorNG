﻿using NUnit.Framework;
using UnityEngine;
using Mirror;

namespace Tests
{
    public class NetworkIdentityTests
    {
        GameObject gameObject;
        NetworkIdentity identity;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            identity = gameObject.AddComponent<NetworkIdentity>();
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(gameObject);
        }

        // prevents https://github.com/vis2k/Mirror/issues/1484
        [Test]
        [Ignore("Figure out a better way to pass this test")]
        public void OnDestroyIsServerTrue()
        {
            // call OnStartServer so that isServer is true
            identity.StartServer();
            Assert.That(identity.IsServer, Is.True);

            // destroy it
            // note: we need runtime .Destroy instead of edit mode .DestroyImmediate
            //       because we can't check isServer after DestroyImmediate
            GameObject.Destroy(gameObject);

            // make sure that isServer is still true so we can save players etc.
            Assert.That(identity.IsServer, Is.EqualTo(true));
        }
    }
}
