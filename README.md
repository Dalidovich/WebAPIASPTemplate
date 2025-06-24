# WebAPIASPTemplate
## Описание проекта

Шаблонный проект web api микросервис на onion архитектуре  
CRUD для сущности **TemplateEntity**

```CSharp
public class TemplateEntity
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreateDate { get; set; }
    public TemplateEntityStatus Status { get; set; }
    public bool IsExist { get; set; }
    public int Number { get; set; }
}
```

+ ASP WEB API + Swagger для просмотра и тестирования функциональности
+ База данных PostgreSQL + Миграции

## Особенности функцианальности функциональности
- Автоматическое создание базы с нужной структурой через **IHostedService**
- Автоматическое заполнение базы SeedData через **IHostedService**
- Доступ к базе через **Repository Pattern**
- Глобальный отлов ошибок через **Midleware**
- Структура внутреннего ответа для общения сервисов
- Update сущности через **builder patthern**

