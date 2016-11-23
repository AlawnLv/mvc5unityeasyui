Create proc [dbo].[P_Sys_GetUserByRoleId]
@RoleId varchar(50)
as
begin
--��ȡ��ɫ���������û�
select a.*,ISNULL(b.SysUserId,0) as flag from SysUser a left join
SysRoleSysUser b on a.Id=b.SysUserId
and b.SysRoleId=@RoleId
order by b.SysRoleId desc
end 