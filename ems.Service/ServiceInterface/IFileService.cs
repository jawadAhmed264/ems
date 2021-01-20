using ems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.ServiceInterface
{
    public interface IFileService
    {
        IEnumerable<FileDetailDto> getAllFile();
        FileDetailDto getFileById(object Id);
        int addFile(FileDetailDto fileDetailDto);
        int updateUpdate(FileDetailDto fileDetailDto, object Id);
        int deleteFile(object Id);
    }
}
