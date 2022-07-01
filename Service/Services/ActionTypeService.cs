using AutoMapper;
using System;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class ActionTypeService : GenericService<ActionType>, IActionTypeService
    {
        
        public ActionTypeService(IGenericRepository<ActionType> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            
        }

        public CustomResponseDto Add(ActionTypeSaveDto saveDto)
        {
            try
            {
                ActionType actionType = _mapper.Map<ActionType>(saveDto);
                actionType.CreateDate = DateTime.Now;
                if(Add(actionType)!=null)
                {
                    ActionTypeResponseDto responseDto = _mapper.Map<ActionTypeResponseDto>(actionType);
                    return new CustomResponseDto() { Data = responseDto, Message="Success : [Data] contains created ActionType data",StatusCode=201 };
                }
                
                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail "+e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(ActionTypeUpdateDto updateDto)
        {
            try
            {
                ActionType actionType = _mapper.Map<ActionType>(updateDto);
                actionType.ModifyDate = DateTime.Now;
                if (Update(actionType) != null)
                {
                    ActionTypeResponseDto responseDto = _mapper.Map<ActionTypeResponseDto>(actionType);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated ActionType data", StatusCode = 201 };
                }
                return new CustomResponseDto() {  Message = "Fail", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail "+ e.Message, StatusCode = 500 };
            }
            
           
        }



        //public CustomResponseDto CreateActionType(ActionTypeSaveDto actionTypeSaveDto)
        //{
        //    if (IsAvailable(x => x.Name == actionTypeSaveDto.Name)) return new CustomResponseDto() { Message = "Fail. ActionType available." };
        //    ActionType actionType;

        //    if (_userService.GetById(actionTypeSaveDto.CreatedBy) != null)
        //    {
        //        try
        //        {
        //            actionType = _mapper.Map<ActionType>(actionTypeSaveDto);

        //            actionType.CreateDate = DateTime.Now;
        //            actionType.ModifyDate = actionType.CreateDate;
        //            actionType.ModifiedBy = actionType.CreatedBy;

        //            if (actionType != null)
        //            {
        //                if (Get(x => x.Name == actionType.Name).Count == 0)
        //                {
        //                    if (Add(actionType) > 0)
        //                    {
        //                        try
        //                        {
        //                            ActionTypeResponseDto actionTypeDto = _mapper.Map<ActionTypeResponseDto>(actionType);
        //                            return new CustomResponseDto() { Data = actionTypeDto, Message = "Success. Data contains created ActionType.", StatusCode = 201 };
        //                        }
        //                        catch (Exception e)
        //                        {

        //                            return new CustomResponseDto() { Message = "Success. "+e.Message, StatusCode = 204 };
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    return new CustomResponseDto() { Message = "ActionType is available.", StatusCode = 403 };
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            return new CustomResponseDto() { Message = "Fail." + e.Message, StatusCode = 500 };
        //        }

        //    }

        //    return new CustomResponseDto() { Message = "CreatedBy user not found.", StatusCode = 404 };
        //}

        //public CustomResponseDto DeleteActionType(int id)
        //{
        //    if (RemoveById(id) > 0)
        //    {
        //        return new CustomResponseDto() { Message = "Success. Entity data deleted.", StatusCode = 204 };
        //    }
        //    return new CustomResponseDto() { Message = "Fail. Entity data not deleted.", StatusCode = 500 };
        //}

        //public CustomResponseDto GetActionType(int id)
        //{
        //    try
        //    {
        //        ActionType actionType = GetById(id);
        //        if (actionType != null)
        //        {
        //            try
        //            {
        //                ActionTypeResponseDto responseDto = _mapper.Map<ActionTypeResponseDto>(actionType);
        //                return new CustomResponseDto() { Data = responseDto, Message = "Success. Data contains ActionType data.", StatusCode = 201 };
        //            }
        //            catch (Exception e)
        //            {
        //                return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //            }
        //        }
        //        else
        //        {
        //            return new CustomResponseDto() { Message = "ActionType not found.", StatusCode = 404 };
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //    }
        //}

        //public CustomResponseDto UpdateActionType(ActionTypeUpdateDto actionTypeUpdateDto)
        //{
        //    try
        //    {
        //        if (!_userService.IsAvailable(x => x.ModifiedBy == actionTypeUpdateDto.ModifiedBy)) return new CustomResponseDto() { Message = "Fail. ModifiedBy User not found.", StatusCode = 404 };
        //        if (!IsAvailable(x => x.ID == actionTypeUpdateDto.ID)) return new CustomResponseDto() { Message = "Fail. ActionType not found.", StatusCode = 404 };
        //        if (IsAvailable(x => x.Name == actionTypeUpdateDto.Name)) return new CustomResponseDto() { Message = "Fail. ActionType available.", StatusCode = 403 };

        //        ActionType actionType = GetById(actionTypeUpdateDto.ID);

        //        if (actionType != null)
        //        {
        //            actionType.Name = actionTypeUpdateDto.Name;
        //            actionType.ModifiedBy = actionTypeUpdateDto.ModifiedBy;
        //            actionType.ModifyDate = DateTime.Now;

        //            if (Update(actionType) > 0)
        //            {
        //                ActionTypeResponseDto responseDto = _mapper.Map<ActionTypeResponseDto>(actionType);
        //                return new CustomResponseDto() { Data = responseDto, Message = "Success. Data contains new values", StatusCode = 201 };

        //            }
        //            else
        //            {
        //                return new CustomResponseDto() { Message = "Fail. Property or properties not correct.", StatusCode = 400 };
        //            }
        //        }
        //        return new CustomResponseDto() { Message = "Server Error.", StatusCode = 500 };

        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //    }
        //}
    }
}
