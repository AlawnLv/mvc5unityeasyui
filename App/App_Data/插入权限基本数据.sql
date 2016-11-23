INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('0','顶级菜单','Root','0','','',0,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('BaseSample','模板样例','Sample by Ajax','SampleFile','SysSample','',0,'',1,'Administrator',NULL,1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Document','我的桌面','Start','PersonDocument','Home/Doc','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Info','我的资料','Info','PersonDocument','Home/Info','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('InfoHome','主页','Home','Information','MIS/Article','',1,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Information','信息中心','Information','OA','','',0,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('ManageInfo','管理中心','Manage Article','Information','MIS/ManageArticle','',4,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('ModuleSetting','模块维护','Module Setting','RightManage','SysModule','',100,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('MyInfo','我的信息','My Article','Information','MIS/MyArticle','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('PersonDocument','个人中心','Person Center','0','','',2,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RightManage','权限管理','Authorities Management','0','','',4,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RoleAuthorize','角色权限设置','Role Authorize','RightManage','SysRight','',6,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RoleManage','角色管理','Role Manage','RightManage','SysRole','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SampleFile','开发指南样例','SampleFile','0','SysSample','',1,'',1,'Administrator',NULL,0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemConfig','系统配置','System Config','SystemManage','SysConfig','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemExcepiton','系统异常','System Exception','SystemManage','SysException','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemJobs','系统任务','System Jobs','TaskScheduling','Jobs/Jobs','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemLog','系统日志','System Log','SystemManage','SysLog','',1,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemManage','系统管理','System Management','0','','',3,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[State],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('UserManage','系统管理员','User Manage','RightManage','SysUser',NULL,1,NULL,1,'Administrator','10  1 2012 12:00AM',1,NULL)


INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleCreate','创建','Create','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleDelete','删除','Delete','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleDetails','详细','Details','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleEdit','编辑','Edit','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleExport','导出','Export','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleQuery','查询','Query','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleSave','保存','Save','BaseSample',0,0)

INSERT INTO [SysRole] ([Id],[Name],[Description],[CreateTime],[CreatePerson]) values ('administrator','超级管理员','全部授权','10  1 2012 12:00AM','Administrator')

INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorSampleFile','SampleFile','administrator',1)
INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorBaseSample','BaseSample','administrator',1)

INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleCreate','administratorBaseSample','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleDelete','administratorBaseSample','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleDetails','administratorBaseSample','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleEdit','administratorBaseSample','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleExport','administratorBaseSample','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleQuery','administratorBaseSample','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleSave','administratorBaseSample','Save',1)

INSERT INTO [SysUser] ([Id],[UserName],[Password],[TrueName],[Card],[MobileNumber],[PhoneNumber],[QQ],[EmailAddress],[OtherContact],[Province],[City],[Village],[Address],[State],[CreateTime],[CreatePerson],[Sex],[Birthday],[JoinDate],[Marital],[Political],[Nationality],[Native],[School],[Professional],[Degree],[DepId],[PosId],[Expertise],[JobState],[Photo],[Attach]) 
values ('admin','admin','01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00','系统管理员',NULL,NULL,'06638888888','324345345','ymnets@sina.com','MSN：ymnets','440000','440100','440101','小小村落',1,'11 18 2012  3:40PM','admin','男','05 18 1900 12:00AM','01  1 2013 12:00AM','未婚','中国','中国','广东揭阳','美国哈佛大学','计算机工程','硕士','20000','20001','勤劳向学,为人友善,乐于助人','在职',NULL,NULL)

INSERT INTO [SysRoleSysUser] ([Id],[SysUserId],[SysRoleId]) values ('adminadministrator','admin','administrator')