using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NSubstitute;
using Services;

namespace Tests.EditorTests
{
    public class ControllerTest
    {
        private Controller _controller;
        private Text _result;
        private InputField _inputFieldA;
        private InputField _inputFieldB;
        private IService _service;

        [OneTimeSetUp]
        public void Setup()
        {
            var rootObject = new GameObject();
            _result = rootObject.AddComponent<Text>();
            _controller  = rootObject.AddComponent<Controller>();
            _inputFieldA = rootObject.AddComponent<InputField>();
            _inputFieldA.name = "A";
            _inputFieldB = new GameObject().AddComponent<InputField>();
            _inputFieldB.name = "B";
            _service = Substitute.For<IService>();
            var privateFieldAccessFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default;
            Type type =  _controller.GetType();
            type.GetField("FieldA", privateFieldAccessFlags)?.SetValue(_controller, _inputFieldA);
            type.GetField("FieldB", privateFieldAccessFlags)?.SetValue(_controller, _inputFieldB);
            type.GetField("Result", privateFieldAccessFlags)?.SetValue(_controller, _result);
            type.GetField("_service", privateFieldAccessFlags)?.SetValue(_controller, _service);
        }
        
        [Test]
        public void ClickHandlerShouldSetResultTo0IfNoValuePassed()
        {
            _controller.ButtonClickHandler();
            Assert.AreEqual("0", _result.text);
        }
        
        [Test]
        public void ClickHandlerShouldSetResultTo0IfInvalidValuePassed()
        {
            _inputFieldA.text = "A";
            _inputFieldB.text = "B";
            _controller.ButtonClickHandler();
            Assert.AreEqual("0", _result.text);
        }

        [Test]
        public void ClickHandlerShouldCallServiceAndSetResultIfValidValuesArePassed()
        {
            _inputFieldA.text = "1";
            _inputFieldB.text = "2";
            _service.Sum(1, 2).Returns(3);
       
            _controller.ButtonClickHandler();

            _service.Received(1).Sum(1, 2);
            Assert.AreEqual("3", _result.text);
        }
        
        
    }
}
