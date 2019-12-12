#import <Foundation/Foundation.h>

typedef enum : NSUInteger {
    Camera,
    Microphone,
    Contacts,
    Voice,
    Notifications,
    Unknown
} Permission;

@implementation PermissionHelper

#define CheckPerm(input) \
if ([perm isEqualToString:@"#input"]) \
return input;

+ (Permission) permissionFromString:(const char *) str {
    NSString * perm = [NSString stringWithUTF8String:str];
    CheckPerm(Camera);
    CheckPerm(Microphone);
    CheckPerm(Contacts);
    CheckPerm(Voice);
    CheckPerm(Notifications);
    return Unknown;
}

+ (BOOL) hasPermission:(Permission) permission {
    return NO;
}

+ (void) requestPermission:(Permission) permission {
    
}

@end

extern "C"
{
    bool __IosHasPermission(char* permission) {
        return NO;        
    }
    
    void __IosRequestPermission(char* permission) {
        
    }
}
