﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.Core;
using App.IBLL;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.Controllers
{
    public class SysRoleController : BaseController
    {
        [Dependency]
        public ISysRoleBLL m_BLL { get; set; }

        [Dependency]
        public ISysRightBLL rightBLL { get; set; }

        private ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [SupportFilter(ActionName = "Index")]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysRoleModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysRoleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Description = r.Description,
                            CreateTime = r.CreateTime,
                            CreatePerson = r.CreatePerson,
                            UserName = rightBLL.GetRefSysUser(r.Id)
                        }).ToArray()
            };
            return MyJson(json, JsonRequestBehavior.AllowGet, "yyyy-MM-dd HH:mm:ss");
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
        public JsonResult Create([Bind(Include = "Name,Description")]SysRoleModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = GetUserId();
            if (ModelState.IsValid)
            {
                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "创建", "SysRole");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "创建", "SysRole");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
        }
        #endregion

        #region 编辑
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysRoleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysRoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "修改", "SysRole");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "修改", "SysRole");
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
            SysRoleModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "SysRole");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "SysRole");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
        }
        #endregion

        #region 设置角色用户
        [SupportFilter(ActionName = "Allot")]
        public ActionResult GetUserByRole(string roleId)
        {
            ViewBag.RoleId = roleId;
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter(ActionName = "Allot")]
        public JsonResult GetUserListByRole(GridPager pager, string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                return Json(0);
            var userList = rightBLL.GetUserByRoleId(ref pager, roleId);

            var jsonData = new
            {
                total = pager.totalRows,
                rows = (
                    from r in userList
                    select new SysUserModel()
                    {
                        Id = r.Id,
                        UserName = r.UserName,
                        TrueName = r.TrueName,
                        Flag = r.flag == "0" ? "0" : "1",
                    }
                ).ToArray()
            };
            return Json(jsonData);
        }

        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult UpdateUserRoleByRoleId(string roleId, string userIds)
        {
            string[] arr = userIds.Split(',');
            if (rightBLL.UpdateSysUserSysRole(roleId, arr))
            {
                LogHandler.WriteServiceLog(GetUserId(), "Ids:" + arr, "成功", "分配用户", "角色设置");
                return Json(JsonHandler.CreateMessage(1, Suggestion.SetSucceed), JsonRequestBehavior.AllowGet);
            }
            string ErrorCol = errors.Error;
            LogHandler.WriteServiceLog(GetUserId(), "Ids:" + arr + ",Errors:" + ErrorCol, "失败", "分配用户", "角色设置");
            return Json(JsonHandler.CreateMessage(0, Suggestion.SetFail), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}