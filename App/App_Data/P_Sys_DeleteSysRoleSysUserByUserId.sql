Create PROCEDURE [dbo].[P_Sys_DeleteSysRoleSysUserByUserId]
@userId varchar(50)
AS
--���½�ɫ�û��м��ϵ��,ǰɾ������
BEGIN
    delete SysRoleSysUser where SysUserId=@userId
END