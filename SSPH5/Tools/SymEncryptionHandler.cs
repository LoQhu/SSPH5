using Microsoft.AspNetCore.DataProtection;

namespace SSPH5.Tools;
public class SymEncryptionHandler
{
    private readonly IDataProtector _protector;
    public SymEncryptionHandler(IDataProtectionProvider protectionProvider)
    {
        _protector = protectionProvider.CreateProtector("SkavensRcool");
    }

    public string EncryptSym(string msg) =>
        _protector.Protect(msg);

    public string DecryptSym(string msg) =>
        _protector.Unprotect(msg);
}
