Create PROCEDURE [dbo].[P_Sys_DeleteSysRoleSysUserByRoleId]
@roleId varchar(50)
AS
--���½�ɫ�û��м��ϵ��,ǰɾ������
BEGIN
    delete SysRoleSysUser where SysRoleId=@roleId
END