import pandas as pd

# Pedir datos al usuario
n = input('Indique nombre: ')
e = int(input('Indique edad: '))
d = input('Indique ciudad: ')
t = input('Indique telefono: ')

# Crear diccionario
dl = {'Nombre': [n], 'Edad': [e], 'Ciudad': [d], 'Telefono': [t]}

# Convertir a DataFrame
df = pd.DataFrame(dl)

# Mostrar el DataFrame
print(df)