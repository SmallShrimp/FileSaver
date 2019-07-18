# FileSaver
VOLO Abp module for file hand pipe

#### 使用

* nuget 安装 X.FileSaver
* 添加处理文件管道
```c#
Configure<FileStoreOptions>(options => {
                options.AddStore<LocalFileStore>();
            });
```

#### 功能

- [x] 本地存储
- [ ] 远程文件存储