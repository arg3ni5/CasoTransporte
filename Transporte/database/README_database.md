# TransporteDB - Database Scripts

## Estructura
/database
  /00_base
    01_create_db.sql
  /01_personas_usuarios
    01_schema.sql
    02_seed.sql
    03_sp.sql            (optional)
  /02_propietarios
    01_schema.sql
    02_seed.sql
    03_sp.sql            (optional)
  /03_vehiculos
    01_schema.sql
    02_seed.sql
    03_sp.sql            (optional)
  /04_multas
    01_schema_temporal.sql
    02_seed.sql
    03_schema_final.sql
    04_sp.sql            (optional)

## Cómo ejecutar (local)
1. Abrir SQL Server Management Studio (SSMS)
2. Ejecutar en orden:

- 00_base/01_create_db.sql
- 01_personas_usuarios/01_schema.sql
- 01_personas_usuarios/02_seed.sql
- 02_propietarios/01_schema.sql
- 02_propietarios/02_seed.sql
- 03_vehiculos/01_schema.sql
- 03_vehiculos/02_seed.sql
- 04_multas/01_schema_temporal.sql
- 04_multas/02_seed.sql

## Importante: Multas (temporal vs final)
- Mientras el módulo Vehículos NO esté integrado, usar:
  - 04_multas/01_schema_temporal.sql
- Cuando Vehículos ya esté integrado y existan registros de Vehículos:
  - Ejecutar 04_multas/03_schema_final.sql
  - Esto fuerza: Multas.IdVehiculo NOT NULL + FK real

## Reglas del repo (obligatorias)
- NO editar scripts de otros módulos sin coordinación.
- Todo cambio de schema debe venir con script nuevo (no “cambios manuales” en local).
- Seeds deben ser mínimos (3-10 registros) y no depender de datos externos.