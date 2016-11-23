﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.Core;
using App.MIS.IBLL;
using App.Models.MIS;
using Microsoft.Practices.Unity;

namespace App.Areas.MIS.Controllers
{
    public class ArticleController : BaseController
    {
        [Dependency]
        public IMIS_ArticleBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<MIS_ArticleModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new MIS_ArticleModel()
                        {
                            Id = r.Id,
                            ChannelId = r.ChannelId,
                            CategoryId = r.CategoryId,
                            Title = r.Title,
                            ImgUrl = r.ImgUrl,
                            BodyContent = r.BodyContent,
                            Sort = r.Sort,
                            Click = r.Click,
                            CheckFlag = r.CheckFlag,
                            Checker = r.Checker,
                            CheckDateTime = r.CheckDateTime,
                            Creater = r.Creater,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };
            return MyJson(json, "yyyy-MM-dd HH:mm:ss");
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(MIS_ArticleModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            if (ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Title, "成功", "创建", "MIS_Article");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Title + "," + ErrorCol, "失败", "创建", "MIS_Article");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            MIS_ArticleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(MIS_ArticleModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Title, "成功", "修改", "MIS_Article");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Title + "," + ErrorCol, "失败", "修改", "MIS_Article");
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
        }
        #endregion

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            MIS_ArticleModel entity = m_BLL.GetById(id);
            return View(entity);
        }
        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "MIS_Article");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "MIS_Article");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
        }
        #endregion
    }
}