package dev.minecraftdlss;
public final class DlssSettings {
 private DlssMode mode=DlssMode.OFF; private float sharpness=0.0f;
 public DlssMode mode(){return mode;} public void mode(DlssMode mode){this.mode=mode;}
 public float sharpness(){return sharpness;} public void sharpness(float value){sharpness=Math.max(0.0f,Math.min(1.0f,value));}
}
