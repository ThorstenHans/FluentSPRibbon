using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class CustomAction_Tests
    {
        [Test]
        public void Create_Should_Build_A_New_Instance_And_Set_The_Id()
        {
            var sut = CustomAction.Create("MyCustomAction");
            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<CustomAction>());
            Assert.That(sut.Id, Is.EqualTo("MyCustomAction"));
        }

        [Test]
        [Category("TestCategory")]
        public void CustomAction_Should_Be_An_Id_Provider()
        {
            var sut = new CustomAction();
            Assert.That(sut.IsIdProvider, Is.True);
        }

        [Test]
        public void CustomAction_Should_Automatically_Provide_An_InnerNode_For_CommandUIExtension_When_A_CommandUIDefinition_Is_Present()
        {
            var sut = CustomAction.Create("MyCustomAction");
            sut.With(() => CommandUIDefinition.Create());

            var actual = sut.ToXml();

            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.StringContaining("<CommandUIExtension"));
        }

        [Test]
        public void CustomAction_Should_Not_Provide_An_InnerNode_CommandUIExtension_When_No_Children_Are_Present()
        {
            var sut = CustomAction.Create("MyCustomAction");
            var actual = sut.ToXml();

            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual, Is.Not.StringContaining("<CommandUIExtension>"));
            Assert.That(actual, Is.Not.StringContaining("</CommandUIExtension>"));

        }

        [Test]
        public void CustomAction_Should_Automatically_Provide_InnerNodes_For_CommandUIExtension_And_CommandUIDefinitions_When_AtLeast_One_CommandUIDefinition_Is_Present()
        {
            var sut = CustomAction.Create("MyCustomAction")
                .With(() => CommandUIDefinition.Create());

            var actual = sut.ToXml();

            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual, Is.StringContaining("<CommandUIExtension>"));
            Assert.That(actual, Is.StringContaining("</CommandUIExtension>"));
            Assert.That(actual, Is.StringContaining("<CommandUIDefinitions>"));
            Assert.That(actual, Is.StringContaining("</CommandUIDefinitions>"));
        }

        [Test]
        public void CustomAction_Should_Automatically_Provide_InnerNodes_For_CommandUIExtension_And_CommandUIHandlers_When_AtLeast_One_CommandUIHandler_Is_Present()
        {
            var sut = CustomAction.Create("MyCustomAction")
                .With(() => CommandUIHandler.Create());

            var actual = sut.ToXml();

            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual, Is.StringContaining("<CommandUIExtension>"));
            Assert.That(actual, Is.StringContaining("</CommandUIExtension>"));

            Assert.That(actual, Is.StringContaining("<CommandUIHandlers>"));
            Assert.That(actual, Is.StringContaining("</CommandUIHandlers>"));
        }
    }
}