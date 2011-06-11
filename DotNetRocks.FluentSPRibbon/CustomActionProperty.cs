namespace DotNetRocks.FluentSPRibbon
{
    public enum CustomActionProperty 
    {
         RequiredAdmin,
        RootWebOnly,
        ShowInLists,
        ControlAssembly,
        ControlClass,
        ControlSrc,
        [TextProvider]
        Description,
        FeatureId,
        GroupId,
        [ImageProvider, UrlProvider]
        ImageUrl,
        Location,
        RegistrationId,
        RegistrationType,
        RequireSiteAdministrator,
        Rights,
        ScriptSrc,
        ScriptBlock,
        Sequence,
        [TextProvider]
        Title,
        UIVersion,
        ShowInReadOnlyContentTypes,
        ShowInSealedContentTypes
    }
}