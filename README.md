# GestorSalud

Aplicación web para gestionar pacientes, médicos y consultas de un centro de salud, hecha con ASP.NET Web Forms y Entity Framework, organizada en capas.

## Qué hace

- **Pacientes:** listado con paginación y orden por columna, alta, edición y baja. La grilla (`GridView`) y el formulario de alta (`DetailsView`) trabajan directo contra el servicio de pacientes a través de un `ObjectDataSource`.
- **Médicos y consultas:** las entidades, los repositorios y los servicios ya están armados. Una consulta une a un paciente con un médico, con fecha, motivo y observaciones.

## Arquitectura en capas

```
C1_UI/        presentación: páginas Web Forms (Pacientes.aspx, Site.Master)
C2_BLL/       lógica de negocio: servicios con sus interfaces (IPacienteService, IMedicoService, IConsultaService)
C3_DAL/       acceso a datos: ApplicationDbContext y repositorios
C4_ENTIDAD/   entidades: Paciente, Medico, ConsultaMedica
```

- Cada capa solo conoce a la de abajo: las páginas usan servicios, los servicios usan repositorios y los repositorios usan el `DbContext`.
- `Repository<TEntity>` es un repositorio genérico con las operaciones comunes (buscar, agregar, modificar, eliminar), y cada entidad tiene el suyo cuando necesita algo propio.
- Los servicios exponen interfaces, así la presentación no depende de la implementación.

## Tecnologías

- C# y ASP.NET Web Forms sobre .NET Framework 4.8.1
- Entity Framework 6 (Code First, con migraciones)
- SQL Server LocalDB
- Bootstrap 5

## Cómo correrlo

1. Abrir `GestorSaludApp.sln` con Visual Studio.
2. Restaurar los paquetes NuGet (Visual Studio lo hace solo al compilar).
3. Crear la base: en la Consola del Administrador de paquetes, ejecutar `Update-Database`. Usa la cadena `DefaultConnection` de `Web.config`, que apunta a `(localdb)\MSSQLLocalDB`.
4. Ejecutar con F5 y entrar a la página de Pacientes.
