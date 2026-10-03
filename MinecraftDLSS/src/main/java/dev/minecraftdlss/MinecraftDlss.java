package dev.minecraftdlss;
import net.fabricmc.api.ModInitializer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
public final class MinecraftDlss implements ModInitializer {
 public static final String MOD_ID="minecraft_dlss";
 public static final Logger LOGGER=LoggerFactory.getLogger(MOD_ID);
 @Override public void onInitialize(){LOGGER.info("Minecraft DLSS core initialized. Native backend: {}",NativeDlssBackend.status());}
}
