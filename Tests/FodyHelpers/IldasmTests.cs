using System;
using Fody;
using Xunit;

#pragma warning disable 618
public class IldasmTests : TestBase
{
    [Fact]
    public void StaticPathResolution()
    {
        Assert.True(Ildasm.FoundIldasm);
    }

    [Fact]
    public void Verify()
    {
        var verify = Ildasm.Decompile(GetAssemblyPath());
#if(NET46)
        ApprovalTests.Approvals.Verify(verify);
#endif
    }

    static string GetAssemblyPath()
    {
        var assembly = typeof(TestBase).Assembly;

        var uri = new UriBuilder(assembly.CodeBase);
        return Uri.UnescapeDataString(uri.Path);
    }
}