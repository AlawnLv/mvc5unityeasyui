﻿using System.Linq;
using App.Models;

namespace App.IDAL
{
    public interface ISysSampleRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        IQueryable<SysSample> GetList(DBContainer db,string queryStr);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Create(SysSample entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        int Delete(string id);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Edit(SysSample entity);

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        SysSample GetById(string id);

        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        bool IsExist(string id);
    }
}
