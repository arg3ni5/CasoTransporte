import pandas as pd
# Crear un DataFrame
datos = {
    'nombre': ['Ana', 'Luis', 'Pedro'],
    'edad': [23, 35, 40],
    'ciudad': ['Madrid', 'Barcelona', 'Valencia']
}
df = pd.DataFrame(datos)
# Mostrar las primeras filas
print (df.head())
