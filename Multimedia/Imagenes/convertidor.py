import os
from PIL import Image

def convertir_webp_a_jpg()
    # Obtiene la ruta donde se está ejecutando el script
    ruta_actual = os.getcwd()
    
    # Crea una carpeta de salida para no mezclar archivos
    carpeta_salida = os.path.join(ruta_actual, convertidas_jpg)
    if not os.path.exists(carpeta_salida)
        os.makedirs(carpeta_salida)

    print(fBuscando archivos en {ruta_actual})

    for archivo in os.listdir(ruta_actual)
        if archivo.lower().endswith(.webp)
            try
                # Abrir la imagen
                nombre_sin_extension = os.path.splitext(archivo)[0]
                img = Image.open(archivo)
                
                # Convertir a RGB (necesario porque WebP soporta transparencia y JPG no)
                img = img.convert(RGB)
                
                # Guardar como JPG
                img.save(os.path.join(carpeta_salida, f{nombre_sin_extension}.jpg), JPEG)
                print(f✔ Convertido {archivo})
            except Exception as e
                print(f✘ Error con {archivo} {e})

    print(n¡Proceso terminado! Revisa la carpeta 'convertidas_jpg'.)

if __name__ == __main__
    convertir_webp_a_jpg()