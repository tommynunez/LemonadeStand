using AutoMapper;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.Toolkit.Diagnostics;
using LemonadeStand.Abstractions.Struct;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace LemonadeStand.Services
{
  public class LemonadeTypeService : ILemonadeTypeService
  {
    private readonly ILogger<LemonadeTypeService> _logger;
    private readonly ILemonadeTypeRepository _lemonadeTypeRepository;
    private readonly IMapper _mapper;

    public LemonadeTypeService(ILogger<LemonadeTypeService> logger,
        ILemonadeTypeRepository lemonadeTypeRepository,
        IMapper mapper)
    {
      _logger = logger;
      _lemonadeTypeRepository = lemonadeTypeRepository;
      _mapper = mapper;
    }

    public async Task DeleteAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_DELETE_SERVICE);
        await _lemonadeTypeRepository.DeleteAsync(id);
      }
      catch (Exception ex)
      {
        _logger.LogError(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_DELETE_SERVICE_ERROR);
      }
    }

    public async Task<IEnumerable<LemonadeType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null)
    {
      try
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETALL_SERVICE);
        var oList = await _lemonadeTypeRepository.GetAllAsync(search, pageIndex, pageSize, sortField);
        return _mapper.Map<IEnumerable<LemonadeType>>(oList);
      }
      catch (Exception ex)
      {
        _logger.LogError(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETALL_SERVICE_ERROR);
        return new List<LemonadeType>();
      }
    }

    public async Task<IEnumerable<LemonadeType>> GetAllLemonadeTypesAsync()
    {
      var oReturn = await _lemonadeTypeRepository.GetAllLemonadeTypesAsync();
      return _mapper.Map<IEnumerable<LemonadeType>>(oReturn);
    }

    public async Task<LemonadeType?> GetByIdAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETBYID_SERVICE);
        var oModel = await _lemonadeTypeRepository.GetByIdAsync(id);
        Guard.IsNotNull(oModel, nameof(oModel));
        return _mapper.Map<LemonadeType>(oModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETBYID_SERVICE_ERROR);
        return new LemonadeType();
      }
    }

    public async Task InsertAsync(LemonadeType lemonadeType)
    {
      try
      {
        Guard.IsNotNull<LemonadeType>(lemonadeType, nameof(lemonadeType));
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_INSERT_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.LemonadeType>(lemonadeType);
        await _lemonadeTypeRepository.InsertAsync(oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_INSERT_SERVICE_ERROR);
      }
    }

    public async Task UpdateAsync(int id, LemonadeType lemonadeType)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        Guard.IsNotNull<LemonadeType>(lemonadeType, nameof(lemonadeType));
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_UPDATE_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.LemonadeType>(lemonadeType);
        await _lemonadeTypeRepository.UpdateAsync(id, oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_UPDATE_SERVICE_ERROR);
      }
    }
  }
}

