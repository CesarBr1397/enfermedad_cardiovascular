using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ActivoFijoAPI.Util;
using ConnectionTools.DBTools;
using Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using TsaakAPI.Entities;
using TsaakAPI.Model.DAO;

namespace ECE.Model.DAO
{
    public class enfermedadCronicaDao
    {
        private ISqlTools _sqlTools;

        public enfermedadCronicaDao(string secondaryConnection)
        {
            this._sqlTools = new SQLTools(secondaryConnection);
        }

        public async Task<ResultOperation<DataTableView<VMCatalog>>> GetPageFetch(int page, int fetch)
        {
            ResultOperation<DataTableView<VMCatalog>> resultOperation = new ResultOperation<DataTableView<VMCatalog>>();

            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync("schemasye.obtener_todos_enfermedades");
            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;

            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0 && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    List<VMCatalog> catalogos = new List<VMCatalog>();

                    foreach (DataRow row in respuestaBD.Data.Tables[0].Rows)
                    {
                        VMCatalog catalogo = new VMCatalog
                        {
                            Id = (int)row["id_enf_cronica"],
                            Nombre = row["nombre"].ToString(),
                            Descripcion = row["descripcion"].ToString(),
                            Estado = (bool?)row["estado"]
                        };
                        catalogos.Add(catalogo);
                    }

                    int totalItems = catalogos.Count;

                    Pager pager = new Pager(page, fetch, totalItems);

                    List<VMCatalog> paginatedResults = catalogos
                        .Skip((page - 1) * fetch)
                        .Take(fetch)
                        .ToList();

                    DataTableView<VMCatalog> dataTableView = new DataTableView<VMCatalog>(pager, paginatedResults);

                    resultOperation.Result = dataTableView;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage("No se encontraron registros en la tabla.");
                }
            }
            else
            {
                Console.WriteLine("Error {0} - {1} - {2} - {3}", respuestaBD.ExisteError, respuestaBD.Mensaje, respuestaBD.CodeSqlError, respuestaBD.Detail);
                throw new Exception(respuestaBD.Mensaje);
            }

            return resultOperation;
        }


        public async Task<ResultOperation<List<EnfermedadCronica>>> GetCompleto()
        {
            ResultOperation<List<EnfermedadCronica>> resultOperation = new ResultOperation<List<EnfermedadCronica>>();

            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync("schemasye.obtener_todos_enfermedades");
            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;

            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0 && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    List<EnfermedadCronica> enfermedades = new List<EnfermedadCronica>();

                    foreach (DataRow row in respuestaBD.Data.Tables[0].Rows)
                    {
                        EnfermedadCronica enfermedad = new EnfermedadCronica
                        {
                            id_enf_cronica = (int)row["id_enf_cronica"],
                            nombre = row["nombre"].ToString(),
                            descripcion = row["descripcion"].ToString(),
                            fecha_registro2 = (DateTime)row["fecha_registro"],
                            fecha_inicio2 = (DateTime)row["fecha_inicio"],
                            estado = (bool)row["estado"],
                            fecha_actualizacion2 = (DateTime)row["fecha_actualizacion"]
                        };
                        enfermedades.Add(enfermedad);
                    }
                    
                    resultOperation.Result = enfermedades;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage($"No se encontraron registros en la tabla.");
                }
            }
            else
            {
                // Manejo de errores (log, excepciones, etc.)
                Console.WriteLine("Error {0} - {1} - {2} - {3}", respuestaBD.ExisteError, respuestaBD.Mensaje, respuestaBD.CodeSqlError, respuestaBD.Detail);
                throw new Exception(respuestaBD.Mensaje);
            }

            return resultOperation;
        }


        public async Task<ResultOperation<List<VMCatalog>>> GetAll()
        {
            ResultOperation<List<VMCatalog>> resultOperation = new ResultOperation<List<VMCatalog>>();

            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync("schemasye.obtener_todos_enfermedades");
            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;

            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0 && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    List<VMCatalog> catalogos = new List<VMCatalog>();

                    foreach (DataRow row in respuestaBD.Data.Tables[0].Rows)
                    {
                        VMCatalog catalogo = new VMCatalog
                        {
                            Id = (int)row["id_enf_cronica"],
                            Nombre = row["nombre"].ToString(),
                            Descripcion = row["descripcion"].ToString(),
                            Estado = (bool?)row["estado"]
                        };
                        catalogos.Add(catalogo);
                    }

                    resultOperation.Result = catalogos;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage($"No se encontraron registros en la tabla.");
                }
            }
            else
            {
                // Manejo de errores (log, excepciones, etc.)
                Console.WriteLine("Error {0} - {1} - {2} - {3}", respuestaBD.ExisteError, respuestaBD.Mensaje, respuestaBD.CodeSqlError, respuestaBD.Detail);
                throw new Exception(respuestaBD.Mensaje);
            }

            return resultOperation;
        }

        public async Task<ResultOperation<VMCatalog>> GetByIdAsync(int id)
        {
            ResultOperation<VMCatalog> resultOperation = new ResultOperation<VMCatalog>();

            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync("schemasye.obtener_id_enfermedad", new ParameterPGsql[]{
                    new ParameterPGsql("p_id_enf_cronica", NpgsqlTypes.NpgsqlDbType.Integer,id),
                });
            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;
            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0
                && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    VMCatalog aux = new VMCatalog
                    {
                        Id = (int)respuestaBD.Data.Tables[0].Rows[0]["id_enf_cronica"],
                        Nombre = respuestaBD.Data.Tables[0].Rows[0]["nombre"].ToString(),
                        Descripcion = respuestaBD.Data.Tables[0].Rows[0]["descripcion"].ToString(),
                        Estado = respuestaBD.Data.Tables[0].Rows[0]["estado"] as bool?,
                    };
                    resultOperation.Result = aux;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage($"No fue posible regresar el registro de la tabla. {respuestaBD.Detail}");
                }
            }
            else
            {
                //TODO Agregar error en el log             
                if (respuestaBD.ExisteError)
                    Console.WriteLine("Error {0} - {1} - {2} - {3}", respuestaBD.ExisteError, respuestaBD.Mensaje, respuestaBD.CodeSqlError, respuestaBD.Detail);
                throw new Exception(respuestaBD.Mensaje);
            }
            return resultOperation;
        }

        public async Task<ResultOperation<int>> AddAsync([FromBody] EnfermedadCronica enfermedad)
        {
            ResultOperation<int> resultOperation = new ResultOperation<int>();

            try
            {
                // Llama a la función de PostgreSQL y pasa los parámetros necesarios
                Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync(
                    "schemasye.agregar_enfermedad",
                    new ParameterPGsql[]
                    {
                new ParameterPGsql("p_nombre", NpgsqlTypes.NpgsqlDbType.Varchar, enfermedad.nombre),
                new ParameterPGsql("p_descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, enfermedad.descripcion),
                new ParameterPGsql("p_fecha_registro", NpgsqlTypes.NpgsqlDbType.Date, enfermedad.fecha_registro),
                new ParameterPGsql("p_fecha_inicio", NpgsqlTypes.NpgsqlDbType.Date, enfermedad.fecha_inicio),
                new ParameterPGsql("p_estado", NpgsqlTypes.NpgsqlDbType.Boolean, enfermedad.estado),
                new ParameterPGsql("p_fecha_actualizacion", NpgsqlTypes.NpgsqlDbType.Date, DateTime.Now)
                    }
                );

                RespuestaBD respuestaBD = await respuestaBDTask;

                // Verifica si la operación fue exitosa
                resultOperation.Success = !respuestaBD.ExisteError;

                if (!respuestaBD.ExisteError)
                {
                    // Obtiene el ID del nuevo registro
                    resultOperation.Result = (int)respuestaBD.Data.Tables[0].Rows[0]["id_enf_cronica"];
                }
                else
                {
                    // Manejo de error si la función PostgreSQL falla
                    resultOperation.Result = 0;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage($"Error al insertar el registro en la base de datos: {respuestaBD.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                // Captura errores no controlados
                resultOperation.Success = false;
                resultOperation.AddErrorMessage($"Error al insertar el registro en la base de datos: {ex.Message}");
            }

            return resultOperation;
        }

        public async Task<ResultOperation<VMCatalog>> UpdateAsync(EnfermedadCronica enfermedad, int id)
        {
            ResultOperation<VMCatalog> resultOperation = new ResultOperation<VMCatalog>();
            enfermedad.id_enf_cronica = id;

            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync(
                "schemasye.actualizar_enfermedad",
                new ParameterPGsql[]
                {
                new ParameterPGsql("p_id_enf_cronica", NpgsqlTypes.NpgsqlDbType.Integer, id),
                new ParameterPGsql("p_nombre", NpgsqlTypes.NpgsqlDbType.Varchar, enfermedad.nombre),
                new ParameterPGsql("p_descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, enfermedad.descripcion),
                new ParameterPGsql("p_fecha_actualizacion", NpgsqlTypes.NpgsqlDbType.Date, DateTime.Now),
                new ParameterPGsql("p_estado", NpgsqlTypes.NpgsqlDbType.Boolean, enfermedad.estado)
                }
            );
            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;
            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0
                && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    VMCatalog aux = new VMCatalog
                    {
                        Id = (int)respuestaBD.Data.Tables[0].Rows[0]["id_enf_cronica"],
                        Nombre = respuestaBD.Data.Tables[0].Rows[0]["nombre"].ToString(),
                        Descripcion = respuestaBD.Data.Tables[0].Rows[0]["descripcion"].ToString(),
                        Estado = respuestaBD.Data.Tables[0].Rows[0]["estado"] as bool?,
                    };
                    resultOperation.Result = aux;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage("No se encontró el registro actualizado.");
                }
            }
            else
            {
                resultOperation.Success = false;
                resultOperation.AddErrorMessage($"Error al actualizar el registro: {respuestaBD.Mensaje}");
            }
            return resultOperation;
        }

        public async Task<ResultOperation<VMCatalog>> DeleteAsync(int id)
        {
            ResultOperation<VMCatalog> resultOperation = new ResultOperation<VMCatalog>();


            Task<RespuestaBD> respuestaBDTask = _sqlTools.ExecuteFunctionAsync(
                "schemasye.borrar_enfermedad",
                new ParameterPGsql[]
                {
                new ParameterPGsql("p_id_enf_cronica", NpgsqlTypes.NpgsqlDbType.Integer, id)
                }
            );

            RespuestaBD respuestaBD = await respuestaBDTask;
            resultOperation.Success = !respuestaBD.ExisteError;
            if (!respuestaBD.ExisteError)
            {
                if (respuestaBD.Data.Tables.Count > 0
                && respuestaBD.Data.Tables[0].Rows.Count > 0)
                {
                    VMCatalog aux = new VMCatalog
                    {
                        Id = (int)respuestaBD.Data.Tables[0].Rows[0]["id_enf_cronica"],
                        Nombre = respuestaBD.Data.Tables[0].Rows[0]["nombre"].ToString(),
                        Descripcion = respuestaBD.Data.Tables[0].Rows[0]["descripcion"].ToString(),
                        Estado = respuestaBD.Data.Tables[0].Rows[0]["estado"] as bool?,
                    };
                    resultOperation.Result = aux;
                }
                else
                {
                    resultOperation.Result = null;
                    resultOperation.Success = false;
                    resultOperation.AddErrorMessage("No se encontró el registro actualizado.");
                }
            }
            else
            {
                resultOperation.Success = false;
                resultOperation.AddErrorMessage($"Error al eliminar el registro: {respuestaBD.Mensaje}");
            }
            return resultOperation;
        }

    }
}
