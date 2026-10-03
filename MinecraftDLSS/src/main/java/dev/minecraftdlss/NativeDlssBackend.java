package dev.minecraftdlss;
public final class NativeDlssBackend {
 private static boolean loaded;
 static{try{System.loadLibrary("minecraft_dlss_native");loaded=true;}catch(UnsatisfiedLinkError ignored){loaded=false;}}
 private NativeDlssBackend(){}
 public static String status(){return loaded?"native bridge loaded":"native bridge unavailable";}
 public static boolean available(){return loaded&&nativeAvailable();}
 private static native boolean nativeAvailable();
}
