using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using QuanLyGiaoHang.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyGiaoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly string _connectionstring;
        public NhanVienController(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("stringSQL");
        }
        // GET: api/<NhanVienController>
        [HttpGet]
        public async Task<IEnumerable<NhanVien>>  Get()
        {
            using(var conn = new SqlConnection(_connectionstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<NhanVien>("USP_GetAll_NhanVien", null, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        // GET api/<NhanVienController>/5
        [HttpGet("{MNV}")]
        public async Task<NhanVien> Get(string MNV)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@manhanvien", MNV);
                var result = await conn.QueryAsync<NhanVien>("USP_Get_NhanVien_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.Single();
            }
        }

        // POST api/<NhanVienController>
        [HttpPost]
        public async Task Post([FromBody] NhanVien nv)
        {
            using(var conn = new SqlConnection(_connectionstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@manhanvien", nv.MANHANVIEN);
                paramaters.Add("@ho", nv.HO);
                paramaters.Add("@ten", nv.TEN);
                paramaters.Add("@ngaysinh", nv.NGAYSINH);
                paramaters.Add("@ngaylamviec", nv.NGAYLAMVIEC);
                paramaters.Add("@diachi", nv.DIACHI);
                paramaters.Add("@dienthoai", nv.DIENTHOAI);
                paramaters.Add("@luongcoban", nv.LUONGCOBAN);
                paramaters.Add("@phucap", nv.PHUCAP);
                await conn.ExecuteAsync("USP_Create_NhanVien", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }

        // PUT api/<NhanVienController>/5
        [HttpPut("{MNV}")]
        public async Task Put(string MNV, [FromBody] NhanVien nv)
        { 
            using(var conn = new SqlConnection(_connectionstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@manhanvien", MNV);
                paramaters.Add("@ho", nv.HO);
                paramaters.Add("@ten", nv.TEN);
                paramaters.Add("@ngaysinh", nv.NGAYSINH);
                paramaters.Add("@ngaylamviec", nv.NGAYLAMVIEC);
                paramaters.Add("@diachi", nv.DIACHI);
                paramaters.Add("@dienthoai", nv.DIENTHOAI);
                paramaters.Add("@luongcoban", nv.LUONGCOBAN);
                paramaters.Add("@phucap", nv.PHUCAP);
                await conn.ExecuteAsync("USP_Update_NhanVien_ByMNV", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }

        // DELETE api/<NhanVienController>/5
        [HttpDelete("{MNV}")]
        public async Task Delete(string MNV)
        {
            using(var conn = new SqlConnection(_connectionstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@manhanvien", MNV);
                await conn.ExecuteAsync("USP_Delete_NhanVien_ByMNV", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
