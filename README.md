## Basic Messages
**Unity Version:**2020.3.0f1
**Firebase SDK Version:**firebase_unity_sdk_8.3.0（dotnet4）
**Used SDK Package:**FirebaseAnalytics、FirebaseMessaging
**Unity Configuration-Scripting Backend:**IL2CPP
**Unity Configuration-Api Compatibility Level:**.NET 4.x
**Test mobile device:**Google Pixel 3、 Redmi 9A

## About the demo project
1.Main codes is in Assets/_scripts/FirebaseSdkManager.cs
2.I have already upload a demo apk called **Demo.apk**
3.**No self defined Andmanifest.xml, no self defined unity activity.**


## Crash Description
1.After install the apk,you shutdown your internet conection,then lauch the app it will crash
2.Crash logs:
FATAL EXCEPTION: UnityMain
    Process: com.tj.sgame, PID: 30789
    java.lang.Error: *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
    Version '2020.3.0f1 (c7b5465681fb)', Build type 'Release', Scripting Backend 'il2cpp', CPU 'arm64-v8a'
    Build fingerprint: 'google/blueline/blueline:9/PQ1A.181105.017.A1/5081125:user/release-keys'
    Revision: 'MP1.0'
    ABI: 'arm64'
    Timestamp: 2021-10-20 16:18:55+0800
    pid: 30789, tid: 30876, name: Thread-6  >>> com.tj.sgame <<<
    uid: 10185
    signal 11 (SIGSEGV), code 1 (SEGV_MAPERR), fault addr 0x8
    Cause: null pointer dereference
        x0  0000000000000008  x1  000000792af3ecb0  x2  0000000000000004  x3  000000792af3ed29
        x4  000000792af3ec68  x5  0000000000000000  x6  455e5e6472606164  x7  7f7f7f7f7f7f7f7f
        x8  0000000000000000  x9  000000792af3ed29  x10 000000792cb54540  x11 000000792c7bae30
        x12 0000000000000008  x13 0000000000000319  x14 0000007a1011eb20  x15 0000000000000000
        x16 000000792b26c3a8  x17 0000007a91cc2c40  x18 0000000000000024  x19 0000000000000000
        x20 000000792af3ecb0  x21 000000792af3ec68  x22 0000000000000000  x23 000000792af3ed29
        x24 0000000000000004  x25 0000000000000008  x26 000000792af3ed28  x27 0000000000000001
        x28 0000000000000000  x29 000000792af3ee98
        sp  000000792af3ec10  lr  000000792b13f3ac  pc  0000007a91cc2c40

	backtrace:
          #00 pc 0000000000082c40  /system/lib64/libc.so (pthread_mutex_lock) (BuildId: d045a7ba5823f9952aea98759165b9c3)
          #01 pc 00000000001fe3a8  /data/app/com.tj.sgame-8G5lBEBbEkGHKa3i-29TgA==/lib/arm64/libFirebaseCppApp-8_3_0.so (firebase::Mutex::Acquire()+4) (BuildId: 8209be713e18b8cc0f0f9cdc20b6d1f4)
          #02 pc 0000000000203c8c  /data/app/com.tj.sgame-8G5lBEBbEkGHKa3i-29TgA==/lib/arm64/libFirebaseCppApp-8_3_0.so (void firebase::ReferenceCountedFutureImpl::CompleteInternal<std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> >, void firebase::ReferenceCountedFutureImpl::CompleteWithResultInternal<std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> > >(firebase::FutureHandle const&, int, char const*, std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> > const&)::'lambda'(std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> >*)>(firebase::FutureHandle const&, int, char const*, void firebase::ReferenceCountedFutureImpl::CompleteWithResultInternal<std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> > >(firebase::FutureHandle const&, int, char const*, std::__ndk1::basic_string<char, std::__ndk1::char_trai...
          #03 pc 0000000000203c40  /data/app/com.tj.sgame-8G5lBEBbEkGHKa3i-29TgA==/lib/arm64/libFirebaseCppApp-8_3_0.so (void firebase::ReferenceCountedFutureImpl::CompleteWithResultInternal<std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> > >(firebase::FutureHandle const&, int, char const*, std::__ndk1::basic_string<char, std::__ndk1::char_traits<char>, std::__ndk1::allocator<char> > const&)+64) (BuildId: 8209be713e18b8cc0f0f9cdc20b6d1f4)
          #04 pc 0000000000270820  /data/app/com.tj.sgame-8G5lBEBbEkGHKa3i-29TgA==/lib/arm64/libFirebaseCppApp-8_3_0.so (firebase::messaging::CompleteStringCallback(_JNIEnv*, _jobject*, firebase::util::FutureResult, char const*, void*)+136) (BuildId: 8209be713e18b8cc0f0f9cdc20b6d1f4)
          #05 pc 0000000000286c18  /data/app/com.tj.sgame-8G5lBEBbEkGHKa3i-29TgA==/lib/arm64/libFirebaseCppApp-8_3_0.so (firebase::util::JniResultCallback_nativeOnResult(_JNIEnv*, _jobject*, _jobject*, unsigned char, unsigned char, _jstring*, long, long)+172) (BuildId: 8209be713e18b8cc0f0f9cdc20b6d1f4)
          #06 pc 0000000000002214  /data/data/com.tj.sgame/cache/oat/arm64/app_resources_lib.odex
		  
		  
		  at libc.pthread_mutex_lock(pthread_mutex_lock:0)
          at libFirebaseCppApp-8_3_0.firebase::Mutex::Acquire()(Acquire:4)