#import <Foundation/Foundation.h>

//Converting String to char for UNITY
//Rememeber that unity can't handle NSString variables
char* cStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

// This is the function we call from unity script
extern "C"
{
    char* __IosGetLanguageShort()
    {
        NSLocale *locale = [NSLocale currentLocale];
        NSString *code = locale.languageCode;
        return cStringCopy([code UTF8String]);
    }
    
    char* __IosGetLanguageLong()
    {
        NSLocale *locale = [NSLocale currentLocale];
        NSLocale *usLocale = [[NSLocale alloc] initWithLocaleIdentifier:@"en_US"];
        NSString *code = locale.languageCode;
        NSString *name = [usLocale displayNameForKey: NSLocaleLanguageCode value: code];
        return cStringCopy([name UTF8String]);
    }
    
    char* __IosGetCountryShort()
    {
        NSLocale *locale = [NSLocale currentLocale];
        NSString *code = locale.countryCode;
        return cStringCopy([code UTF8String]);
    }
    
    char* __IosGetCountryLong()
    {
        NSLocale *locale = [NSLocale currentLocale];
        NSLocale *usLocale = [[NSLocale alloc] initWithLocaleIdentifier:@"en_US"];
        NSString *code = locale.countryCode;
        NSString *name = [usLocale displayNameForKey: NSLocaleCountryCode value: code];
        return cStringCopy([name UTF8String]);
    }
}
