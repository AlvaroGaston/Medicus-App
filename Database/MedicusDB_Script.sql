-- ============================================================================
-- SCRIPT DE BASE DE DATOS PARA MEDICUS-APP
-- Optimizado para integración con aplicación C# (N-Capas)
-- Base de datos: MedicusDB2_0
-- ============================================================================

-- Crear base de datos
CREATE DATABASE MedicusDB2_0;
GO

USE MedicusDB2_0;
GO

-- ============================================================================
-- 1. TABLAS INDEPENDIENTES (Sin dependencias)
-- ============================================================================

-- Tabla de Usuarios (Sistema)
CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Documento VARCHAR(20) NOT NULL UNIQUE,
    NombreCompleto VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) UNIQUE,
    Clave VARCHAR(255) NOT NULL,
    Estado BIT DEFAULT 1,
    IdGrupo INT,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Grupos (Roles)
CREATE TABLE Grupo (
    IdGrupo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla de Especialidades
CREATE TABLE Especialidad (
    IdEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion TEXT,
    DuracionTurnoMinutos INT DEFAULT 30,
    PrecioConsulta DECIMAL(10,2),
    Estado BIT DEFAULT 1
);

-- Tabla de Pacientes
CREATE TABLE Paciente (
    IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
    Dni VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE,
    Sexo CHAR(1),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    Direccion VARCHAR(255),
    ObraSocial VARCHAR(100),
    NumeroAfiliado VARCHAR(50),
    ContactoEmergencia VARCHAR(100),
    TelefonoEmergencia VARCHAR(50),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

-- Tabla de Médicos
CREATE TABLE Medico (
    IdMedico INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Dni VARCHAR(20) UNIQUE,
    FechaNacimiento DATE,
    Sexo CHAR(1),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    Direccion VARCHAR(255),
    Matricula VARCHAR(50) UNIQUE,
    IdEspecialidad INT,
    DiasAtencion VARCHAR(100),
    HoraInicio TIME,
    HoraFin TIME,
    DuracionTurno INT DEFAULT 30,
    FechaIngreso DATE,
    FechaBaja DATE,
    Sueldo DECIMAL(10,2),
    Estado BIT DEFAULT 1,
    FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad)
);

-- ============================================================================
-- 2. TABLAS DE CONFIGURACIÓN Y AUDITORÍA
-- ============================================================================

-- Tabla de Bitácora (Auditoría)
CREATE TABLE Bitacora (
    IdBitacora INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    UsuarioNombre VARCHAR(100),
    Accion VARCHAR(100),
    Modulo VARCHAR(100),
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

-- Tabla de Configuración del Sistema
CREATE TABLE ConfiguracionSistema (
    IdConfiguracion INT IDENTITY(1,1) PRIMARY KEY,
    Clave VARCHAR(100) NOT NULL UNIQUE,
    Valor TEXT,
    Tipo VARCHAR(50),
    Descripcion TEXT,
    FechaModificacion DATETIME DEFAULT GETDATE()
);

-- Tabla de Notificaciones
CREATE TABLE Notificacion (
    IdNotificacion INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    Tipo VARCHAR(50),
    Titulo VARCHAR(100),
    Mensaje TEXT,
    FechaEnvio DATETIME DEFAULT GETDATE(),
    Leida BIT DEFAULT 0,
    FechaLectura DATETIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

-- Tabla de Permisos (Matriz de Roles y Permisos)
CREATE TABLE Permiso (
    IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
    IdGrupo INT NOT NULL,
    NombreMenu VARCHAR(100),
    PuedeVer BIT DEFAULT 0,
    PuedeCrear BIT DEFAULT 0,
    PuedeEditar BIT DEFAULT 0,
    PuedeEliminar BIT DEFAULT 0,
    FOREIGN KEY (IdGrupo) REFERENCES Grupo(IdGrupo),
    UNIQUE (IdGrupo, NombreMenu)
);

-- ============================================================================
-- 3. TABLA CENTRAL DE TURNOS
-- ============================================================================

CREATE TABLE Turno (
    IdTurno INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT NOT NULL,
    IdMedico INT NOT NULL,
    IdEspecialidad INT,
    FechaTurno DATE NOT NULL,
    HoraTurno TIME NOT NULL,
    DuracionMinutos INT DEFAULT 30,
    Estado VARCHAR(20) DEFAULT 'Pendiente',
    Motivo TEXT,
    Observaciones TEXT,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CreadoPor INT,
    FechaModificacion DATETIME,
    ModificadoPor INT,
    FOREIGN KEY (IdPaciente) REFERENCES Paciente(IdPaciente),
    FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico),
    FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad),
    FOREIGN KEY (CreadoPor) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (ModificadoPor) REFERENCES Usuario(IdUsuario),
    -- Índice para optimizar búsquedas por médico y fecha
    UNIQUE (IdMedico, FechaTurno, HoraTurno)
);

-- ============================================================================
-- 4. TABLAS CLÍNICAS (Dependientes de Turnos)
-- ============================================================================

-- Tabla de Evolución Clínica / Historia Clínica
CREATE TABLE EvolucionClinica (
    IdEvolucion INT IDENTITY(1,1) PRIMARY KEY,
    IdTurno INT NOT NULL,
    IdMedico INT NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Anamnesis TEXT,
    ExamenFisico TEXT,
    Diagnostico TEXT,
    Tratamiento TEXT,
    Observaciones TEXT,
    ProximoControl DATETIME,
    FOREIGN KEY (IdTurno) REFERENCES Turno(IdTurno) ON DELETE CASCADE,
    FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico)
);

-- Tabla de Estudios Médicos
CREATE TABLE EstudioMedico (
    IdEstudio INT IDENTITY(1,1) PRIMARY KEY,
    IdTurno INT NOT NULL,
    TipoEstudio VARCHAR(100),
    Descripcion TEXT,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    FechaRealizacion DATETIME,
    Estado VARCHAR(20) DEFAULT 'Solicitado',
    Resultado TEXT,
    ArchivoAdjunto VARCHAR(500),
    NombreArchivo VARCHAR(255),
    FOREIGN KEY (IdTurno) REFERENCES Turno(IdTurno) ON DELETE CASCADE
);

-- Tabla de Derivaciones
CREATE TABLE Derivacion (
    IdDerivacion INT IDENTITY(1,1) PRIMARY KEY,
    IdTurnoOrigen INT,
    IdTurnoDestino INT,
    IdEspecialidadDestino INT NOT NULL,
    IdMedicoOrigen INT NOT NULL,
    IdMedicoDestino INT,
    Motivo TEXT,
    Fecha DATETIME DEFAULT GETDATE(),
    Estado VARCHAR(20) DEFAULT 'Pendiente',
    Observaciones TEXT,
    FOREIGN KEY (IdTurnoOrigen) REFERENCES Turno(IdTurno),
    FOREIGN KEY (IdTurnoDestino) REFERENCES Turno(IdTurno),
    FOREIGN KEY (IdEspecialidadDestino) REFERENCES Especialidad(IdEspecialidad),
    FOREIGN KEY (IdMedicoOrigen) REFERENCES Medico(IdMedico),
    FOREIGN KEY (IdMedicoDestino) REFERENCES Medico(IdMedico)
);

-- ============================================================================
-- 5. TABLA DE REPORTES FINANCIEROS
-- ============================================================================

CREATE TABLE ReporteFinanciero (
    IdReporte INT IDENTITY(1,1) PRIMARY KEY,
    TipoReporte VARCHAR(50),
    Nombre VARCHAR(100),
    Descripcion TEXT,
    FechaInicio DATE,
    FechaFin DATE,
    TotalIngresos DECIMAL(12,2) DEFAULT 0,
    TotalEgresos DECIMAL(12,2) DEFAULT 0,
    Diferencia DECIMAL(12,2),
    DatosJSON TEXT,
    GeneradoPor INT,
    FechaGeneracion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GeneradoPor) REFERENCES Usuario(IdUsuario)
);

-- ============================================================================
-- 6. ÍNDICES PARA OPTIMIZACIÓN
-- ============================================================================

CREATE INDEX IX_Turno_Paciente ON Turno(IdPaciente);
CREATE INDEX IX_Turno_Medico ON Turno(IdMedico);
CREATE INDEX IX_Turno_Fecha ON Turno(FechaTurno);
CREATE INDEX IX_Turno_Estado ON Turno(Estado);
CREATE INDEX IX_EvolucionClinica_Turno ON EvolucionClinica(IdTurno);
CREATE INDEX IX_EstudioMedico_Turno ON EstudioMedico(IdTurno);
CREATE INDEX IX_Bitacora_Usuario ON Bitacora(IdUsuario);
CREATE INDEX IX_Bitacora_Fecha ON Bitacora(Fecha);
CREATE INDEX IX_Notificacion_Usuario ON Notificacion(IdUsuario);
CREATE INDEX IX_Permiso_Grupo ON Permiso(IdGrupo);

-- ============================================================================
-- 7. RELACIÓN FOREIGN KEY USUARIO -> GRUPO (Agregada después de crear ambas)
-- ============================================================================

ALTER TABLE Usuario 
ADD CONSTRAINT FK_Usuario_Grupo FOREIGN KEY (IdGrupo) REFERENCES Grupo(IdGrupo);

-- ============================================================================
-- 8. DATOS INICIALES (Configuración Básica)
-- ============================================================================

-- Insertar Grupos base
INSERT INTO Grupo (Nombre) VALUES ('Administrador');
INSERT INTO Grupo (Nombre) VALUES ('Médico');
INSERT INTO Grupo (Nombre) VALUES ('Recepcionista');
INSERT INTO Grupo (Nombre) VALUES ('Paciente');

-- Insertar Especialidades comunes
INSERT INTO Especialidad (Nombre, Descripcion, DuracionTurnoMinutos, PrecioConsulta) VALUES 
('Medicina General', 'Consulta de medicina general', 30, 500.00),
('Cardiología', 'Especialidad en enfermedades del corazón', 45, 1000.00),
('Dermatología', 'Especialidad en enfermedades de la piel', 30, 800.00),
('Pediatría', 'Medicina especializada para niños', 30, 600.00),
('Oftalmología', 'Especialidad en enfermedades de los ojos', 40, 900.00);

-- Insertar Configuración inicial
INSERT INTO ConfiguracionSistema (Clave, Valor, Tipo, Descripcion) VALUES 
('NombreClinica', 'Clínica Medicus', 'STRING', 'Nombre de la institución'),
('DireccionClinica', 'Calle Principal 123', 'STRING', 'Dirección de la clínica'),
('TelefonoClinica', '+54 (XXX) XXXX-XXXX', 'STRING', 'Teléfono de contacto'),
('EmailClinica', 'contacto@medicus.com', 'STRING', 'Email de contacto'),
('DuracionSesion', '30', 'INT', 'Duración de sesión en minutos'),
('IntentosMaximosFallo', '3', 'INT', 'Intentos máximos de login fallidos');

-- ============================================================================
-- 9. PROCEDIMIENTOS ALMACENADOS ÚTILES
-- ============================================================================

-- Listar turnos del día con detalles
CREATE PROCEDURE SP_ObtenerTurnosDelDia
    @Fecha DATE
AS
BEGIN
    SELECT 
        t.IdTurno,
        t.IdPaciente,
        t.IdMedico,
        p.Nombre + ' ' + p.Apellido AS PacienteNombre,
        p.Dni AS PacienteDni,
        m.Nombre + ' ' + m.Apellido AS MedicoNombre,
        e.Nombre AS Especialidad,
        t.FechaTurno,
        t.HoraTurno,
        t.DuracionMinutos,
        t.Estado,
        t.Motivo
    FROM Turno t
    INNER JOIN Paciente p ON t.IdPaciente = p.IdPaciente
    INNER JOIN Medico m ON t.IdMedico = m.IdMedico
    INNER JOIN Especialidad e ON t.IdEspecialidad = e.IdEspecialidad
    WHERE CAST(t.FechaTurno AS DATE) = @Fecha
    ORDER BY t.HoraTurno ASC;
END;
GO

-- Contar turnos pendientes por especialidad
CREATE PROCEDURE SP_TurnosPendientesPorEspecialidad
AS
BEGIN
    SELECT 
        e.Nombre AS Especialidad,
        COUNT(t.IdTurno) AS TurnosPendientes
    FROM Turno t
    INNER JOIN Especialidad e ON t.IdEspecialidad = e.IdEspecialidad
    WHERE t.Estado = 'Pendiente'
    GROUP BY e.Nombre
    ORDER BY TurnosPendientes DESC;
END;
GO

-- Obtener próximos turnos de un paciente
CREATE PROCEDURE SP_ObtenerProximosTurnosPaciente
    @IdPaciente INT
AS
BEGIN
    SELECT TOP 5
        t.IdTurno,
        m.Nombre + ' ' + m.Apellido AS Medico,
        e.Nombre AS Especialidad,
        t.FechaTurno,
        t.HoraTurno,
        t.Estado
    FROM Turno t
    INNER JOIN Medico m ON t.IdMedico = m.IdMedico
    INNER JOIN Especialidad e ON t.IdEspecialidad = e.IdEspecialidad
    WHERE t.IdPaciente = @IdPaciente 
        AND t.FechaTurno >= CAST(GETDATE() AS DATE)
        AND t.Estado != 'Cancelado'
    ORDER BY t.FechaTurno ASC, t.HoraTurno ASC;
END;
GO

-- Generar reporte de ocupación médica
CREATE PROCEDURE SP_ReporteOcupacionMedica
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SELECT 
        m.IdMedico,
        m.Nombre + ' ' + m.Apellido AS Medico,
        e.Nombre AS Especialidad,
        COUNT(CASE WHEN t.Estado = 'Realizado' THEN 1 END) AS TurnosRealizados,
        COUNT(CASE WHEN t.Estado = 'Pendiente' THEN 1 END) AS TurnosPendientes,
        COUNT(CASE WHEN t.Estado = 'Cancelado' THEN 1 END) AS TurnosCancelados,
        COUNT(t.IdTurno) AS TotalTurnos
    FROM Medico m
    LEFT JOIN Especialidad e ON m.IdEspecialidad = e.IdEspecialidad
    LEFT JOIN Turno t ON m.IdMedico = t.IdMedico 
        AND t.FechaTurno BETWEEN @FechaInicio AND @FechaFin
    GROUP BY m.IdMedico, m.Nombre, m.Apellido, e.Nombre
    ORDER BY m.Nombre;
END;
GO

-- ============================================================================
-- NOTAS FINALES
-- ============================================================================
/*
✓ CARACTERÍSTICAS DEL SCRIPT:
  • Nombres de tablas y columnas coinciden con la app C#
  • Usa INT IDENTITY para PKs (como en SqlClient)
  • Índices optimizados para consultas frecuentes
  • Relaciones con CASCADE para datos clínicos
  • Includes iniciales de Grupos y Especialidades
  • 4 Stored Procedures para operaciones comunes

✓ PRÓXIMOS PASOS EN LA APP:
  1. Actualizar ConexionDB.cs si cambia el servidor/BD
  2. Crear DAL para Especialidad, EvolucionClinica, EstudioMedico
  3. Crear entidades correspondientes en Medicus.Entidades
  4. Implementar la lógica de negocio en Medicus.BLL

✓ CONSIDERACIONES DE SEGURIDAD:
  • Las contraseñas deben encriptarse en la app (nunca guardar en plain text)
  • Usar parametrized queries (ya lo hace la app)
  • Implementar cierre de sesión por timeout
  • Validar permisos en cada operación
*/
