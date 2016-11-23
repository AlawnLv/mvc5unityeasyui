Create proc [dbo].[P_Sys_UpdateSysRightRightFlag]
@moduleId varchar(200),@roleId varchar(200)
as
begin
--�����ϼ�ģ���rightflag��ʶ
declare @count int
--��һ�㣺�ɲ���Ȩ�������ģ��Ȩ��
select @count=COUNT(*) from SysRightOperate where RightId=@roleId+@moduleId and IsValid=1

if(@count>0)
begin
    update SysRight set Rightflag=1 where ModuleId=@moduleId and RoleId=@roleId
end
else
begin
    update SysRight set Rightflag=0 where ModuleId=@moduleId and RoleId=@roleId
end
--������һ��
declare @parentId varchar(50)
set @parentId=@moduleId

while(@parentId<>'0')
begin
    select @parentid=ParentId from SysModule where Id=@parentId
    if (@parentId is null)
    begin
        return
    end
    
    select @count=COUNT(*) from SysRight where ModuleId in
        (select Id from SysModule where ParentId=@parentId)
        and RoleId =@roleId
        and Rightflag=1
    
    if(@count>0)
    begin
        update SysRight set Rightflag=1 where ModuleId=@parentId and RoleId=@roleId
    end
    else
    begin
        update SysRight set Rightflag=0 where ModuleId=@parentId and RoleId=@roleId
    end
end
end