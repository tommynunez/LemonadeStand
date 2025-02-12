using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using LemonadeStand.Abstractions.Struct;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Diagnostics;

namespace LemonadeStand.Services
{
  public class SizeService : ISizeService
  {
    private readonly ILogger<SizeService> _logger;
    private readonly ISizeRepository _sizeRepository;
    private readonly IMapper _mapper;

    public SizeService(ILogger<SizeService> logger,
        ISizeRepository sizeRepository,
        IMapper mapper)
    {
      _logger = logger;
      _sizeRepository = sizeRepository;
      _mapper = mapper;
    }

    public async Task DeleteAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_DELETE_SERVICE);
        await _sizeRepository.DeleteAsync(id);
      }
      catch (Exception ex)
      {
        _logger.LogError(SizeLogMessages.SIZE_INVOKE_DELETE_SERVICE_ERROR);
      }
    }

    public async Task<IEnumerable<Size>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null)
    {
      try
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETALL_SERVICE_ERROR);
        var oList = await _sizeRepository.GetAllAsync(search, pageIndex, pageSize, sortField);
        return _mapper.Map<IEnumerable<Size>>(oList);
      }
      catch (Exception ex)
      {
        _logger.LogError(SizeLogMessages.SIZE_INVOKE_GETALL_SERVICE_ERROR);
        return new List<Size>();
      }
    }

    public async Task<IEnumerable<Size>> GetAllSizesAsync()
    {
      var oReturn = await _sizeRepository.GetAllSizesAsync();
      return _mapper.Map<IEnumerable<Size>>(oReturn);
    }

    public async Task<Size> GetByIdAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETBYID_SERVICE);
        var oModel = await _sizeRepository.GetByIdAsync(id);
        Guard.IsNotNull(oModel, nameof(oModel));
        return _mapper.Map<Size>(oModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(SizeLogMessages.SIZE_INVOKE_GETBYID_SERVICE_ERROR);
        return new Size();
      }
    }

    public async Task InsertAsync(Size size)
    {
      try
      {
        Guard.IsNotNull<Size>(size, nameof(size));
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_INSERT_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.Size>(size);
        await _sizeRepository.InsertAsync(oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(SizeLogMessages.SIZE_INVOKE_INSERT_SERVICE_ERROR);
      }
    }

    public async Task UpdateAsync(int id, Size size)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        Guard.IsNotNull<Size>(size, nameof(size));
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_UPDATE_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.Size>(size);
        await _sizeRepository.UpdateAsync(id, oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(SizeLogMessages.SIZE_INVOKE_UPDATE_SERVICE_ERROR);
      }
    }
  }
}

