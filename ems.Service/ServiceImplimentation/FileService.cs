using ems.Data.Models;
using ems.Data.Repository;
using ems.DTO;
using ems.Service.AutoMapperInfrastructure;
using ems.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ems.Service.ServiceImplimentation
{
    public class FileService : IFileService
    {
        private IGenericRepository<FileDetail> repository = null;

        public FileService()
        {
            this.repository = new GenericRepository<FileDetail>();
        }

        public FileService(IGenericRepository<FileDetail> repository)
        {
            this.repository = repository;
        }

        public int addFile(FileDetailDto fileDetailDto)
        {
            FileDetail file = ObjectMapper.Mapper.Map<FileDetail>(fileDetailDto);
            repository.Insert(file);
            int status = repository.Save();
            return status;
        }

        public int deleteFile(object Id)
        {
            repository.Delete(Id);
            int Status = repository.Save();
            return Status;
        }

        public IEnumerable<FileDetailDto> getAllFile()
        {
            IQueryable<FileDetailDto> FileList = repository.GetAll().
                Select(file => ObjectMapper.Mapper.Map<FileDetailDto>(file));
            return FileList.AsEnumerable().ToList();
        }

        public FileDetailDto getFileById(object Id)
        {
            FileDetail file = repository.GetById(Id);
            return ObjectMapper.Mapper.Map<FileDetailDto>(file);
        }

        public int updateUpdate(FileDetailDto fileDetailDto, object Id)
        {
            throw new NotImplementedException();
        }
    }
}
