Create PROCEDURE [dbo].[P_Sys_UpdateSysRoleSysUser]
@roleId varchar(50),@userId varchar(50)
AS
--���½�ɫ�û��м��ϵ��
BEGIN
    insert into SysRoleSysUser(Id,SysRoleId,SysUserId)
        values(@userId+@roleId,@roleId,@userId)
END