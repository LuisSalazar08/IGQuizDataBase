import sys
import os
import subprocess

def recortar_audio(ruta_archivo, limite_segundos=15):
    # Limpiar comillas extra que Windows añade al arrastrar archivos
    ruta_archivo = ruta_archivo.strip('"').strip("'")

    if not os.path.isfile(ruta_archivo):
        print(f"❌ Error: No se encontró el archivo en la ruta:\n{ruta_archivo}")
        return

    # Obtener el directorio, nombre y extensión original
    directorio = os.path.dirname(ruta_archivo)
    nombre_base, ext = os.path.splitext(os.path.basename(ruta_archivo))
    
    # Validar que sea un archivo de audio (puedes agregar más si lo necesitas)
    if ext.lower() not in ['.mp3', '.wav', '.ogg', '.webm']:
        print(f"⚠️ El archivo '{nombre_base}{ext}' no parece ser un audio válido.")
        return

    # Crear el nombre del nuevo archivo en la misma carpeta
    ruta_destino = os.path.join(directorio, f"{nombre_base}_15s{ext}")

    print(f"⏳ Procesando: {nombre_base}{ext}...")

    # Comando FFmpeg para recortar sin perder calidad
    comando = [
        'ffmpeg',
        '-y',
        '-i', ruta_archivo,
        '-t', str(limite_segundos),
        '-c', 'copy',
        ruta_destino
    ]

    try:
        subprocess.run(comando, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL, check=True)
        print(f"✅ ¡Éxito! Archivo guardado como: {nombre_base}_15s{ext}\n")
    except subprocess.CalledProcessError:
        print(f"❌ Error al procesar {nombre_base}{ext} con FFmpeg.")
    except FileNotFoundError:
        print("❌ ERROR CRÍTICO: No se encontró 'ffmpeg'.")

if __name__ == "__main__":
    print("=== RECORTADOR DE AUDIOS RÁPIDO (15s) ===")
    
    # MODO 1: Arrastrar el archivo sobre el icono del script de Python en el explorador
    if len(sys.argv) > 1:
        for argumento in sys.argv[1:]:
            recortar_audio(argumento)
        input("Presiona Enter para cerrar...")
        
    # MODO 2: Ejecutar el script y arrastrar el archivo a la ventana de la consola
    else:
        print("Instrucciones: Arrastra un archivo de audio hacia esta ventana y presiona Enter.")
        ruta_ingresada = input("> ")
        
        if ruta_ingresada.strip():
            recortar_audio(ruta_ingresada)
            
        input("Presiona Enter para cerrar...")