﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Common;
using App.BLL.Core;
using App.MIS.IBLL;
using App.MIS.IDAL;
using App.Models;
using App.Models.MIS;
using Microsoft.Practices.Unity;

namespace App.MIS.BLL
{
    public class MIS_Article_CategoryBLL : BaseBLL, IMIS_Article_CategoryBLL
    {
        [Dependency]
        public IMIS_Article_CategoryRepository m_Rep { get; set; }
        
        public List<MIS_Article_CategoryModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<MIS_Article_Category> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Name.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<MIS_Article_CategoryModel> CreateModelList(ref IQueryable<MIS_Article_Category> queryData)
        {

            List<MIS_Article_CategoryModel> modelList = (from r in queryData
                                                         select new MIS_Article_CategoryModel
                                                         {
                                                             BodyContent = r.BodyContent,
                                                             ChannelId = r.ChannelId ?? 0,
                                                             CreateTime = r.CreateTime ?? DateTime.Now,
                                                             Enable = r.Enable,
                                                             Id = r.Id,
                                                             ImgUrl = r.ImgUrl,
                                                             Name = r.Name,
                                                             ParentId = r.ParentId,
                                                             Sort = r.Sort ?? 0
                                                         }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article_Category();
                entity.BodyContent = model.BodyContent;
                entity.ChannelId = model.ChannelId;
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Sort = model.Sort;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                errors.Add(Suggestion.InsertFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                errors.Add(Suggestion.DeleteFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        Transaction.Current.Rollback();
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Edit(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.BodyContent = model.BodyContent;
                entity.ChannelId = model.ChannelId;
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Sort = model.Sort;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                errors.Add(Suggestion.EditFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public MIS_Article_CategoryModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article_Category entity = m_Rep.GetById(id);
                MIS_Article_CategoryModel model = new MIS_Article_CategoryModel();
                model.BodyContent = entity.BodyContent;
                model.ChannelId = entity.ChannelId ?? 0;
                model.CreateTime = entity.CreateTime ?? DateTime.Now;
                model.Enable = entity.Enable;
                model.Id = entity.Id;
                model.ImgUrl = entity.ImgUrl;
                model.Name = entity.Name;
                model.ParentId = entity.ParentId;
                model.Sort = entity.Sort ?? 0;
                return model;
            }
            return null;
        }

        public bool IsExists(string id)
        {
            if (db.MIS_Article_Category.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
