# README для проекта ArchiveFund Android

## Обзор
Это Android-приложение является адаптацией десктопного C# приложения ArchiveFund для платформы Android (API 26+, Android 8.0 Oreo).

## Структура проекта

```
ArchiveFundAndroid/
├── app/
│   ├── src/main/
│   │   ├── java/com/archivfund/app/
│   │   │   ├── activities/          # Активности (UI экраны)
│   │   │   │   ├── LoginActivity.java    # Экран авторизации
│   │   │   │   └── MainActivity.java     # Главный экран
│   │   │   ├── adapters/            # Адаптеры для RecyclerView
│   │   │   │   └── GenericListAdapter.java
│   │   │   ├── models/              # Модели данных
│   │   │   │   ├── User.java             # Модель пользователя
│   │   │   │   ├── Box.java              # Модель коробки
│   │   │   │   ├── Group.java            # Модель группы
│   │   │   │   └── Document.java         # Модель документа
│   │   │   ├── network/             # Сетевые компоненты
│   │   │   │   └── DatabaseHelper.java   # Работа с MySQL
│   │   │   └── utils/               # Утилиты
│   │   │       └── ConfigManager.java    # Управление конфигурацией
│   │   └── res/                   # Ресурсы
│   │       ├── layout/              # XML макеты
│   │       ├── menu/                # Меню навигации
│   │       ├── drawable/            # Векторные иконки
│   │       ├── values/              # Строки, цвета, темы
│   │       └── mipmap-*/            # Иконки приложения
│   └── build.gradle               # Зависимости приложения
├── build.gradle                   # Конфигурация проекта
└── settings.gradle                # Настройки проекта
```

## Основные компоненты

### 1. LoginActivity (Авторизация)
Адаптировано из `Authorization.cs`:
- Поля ввода логина и пароля
- Проверка учетных данных через MySQL
- Хэширование паролей SHA-512
- Переход на главный экран при успешной авторизации

### 2. MainActivity (Главный экран)
Адаптировано из `MainForm.cs`:
- Navigation Drawer с меню
- Отображение данных в RecyclerView
- Поддержка ролей (Admin, Manager, None)
- Статусная строка

### 3. DatabaseHelper (Работа с БД)
Адаптировано из `Sql.cs`:
- Прямое подключение к MySQL
- Выполнение SELECT, INSERT, UPDATE, DELETE запросов
- Подготовка параметров
- Обработка ошибок

### 4. ConfigManager (Конфигурация)
Адаптировано из `Program.cs`:
- Хранение настроек подключения
- SharedPreferences вместо config.ini
- Валидация адреса сервера

## Модели данных

| C# Класс | Android Класс | Описание |
|----------|---------------|----------|
| User | User.java | Пользователь системы |
| Boxes | Box.java | Коробки для документов |
| Group | Group.java | Учебные группы |
| Documents | Document.java | Документы |

## Таблицы базы данных

Приложение работает со следующими таблицами:
- Boxes - коробки
- DeletedDocuments - удаленные документы
- DeletedStudentsPersFiles - удаленные личные дела
- Documents - документы
- DocumentTypes - типы документов
- Group - группы
- Student - студенты
- StudentsPersFiles - личные дела студентов
- User - пользователи

## Требования

- **Минимальная версия Android**: API 26 (Android 8.0 Oreo)
- **Целевая версия Android**: API 34
- **База данных**: MySQL 8.0+
- **Сетевое подключение**: Требуется для работы с БД

## Разрешения

- `INTERNET` - доступ к сети
- `ACCESS_NETWORK_STATE` - проверка состояния сети
- `WRITE_EXTERNAL_STORAGE` - запись файлов (до Android 9)
- `READ_EXTERNAL_STORAGE` - чтение файлов (до Android 12)

## Сборка и запуск

1. Откройте проект в Android Studio
2. Синхронизируйте Gradle зависимости
3. Измените настройки подключения в LoginActivity или создайте экран настроек
4. Запустите на устройстве или эмуляторе с API 26+

## Примечания по адаптации

### Отличия от десктопной версии:

1. **UI/UX**: 
   - WinForms → Material Design
   - DataGridView → RecyclerView
   - MenuStrip → Navigation Drawer

2. **Хранение данных**:
   - config.ini → SharedPreferences
   - .resx файлы → strings.xml

3. **Многопоточность**:
   - UI операции только в главном потоке
   - Сетевые запросы в фоновом потоке

4. **Жизненный цикл**:
   - Формы → Activities
   - Управление состоянием через onSaveInstanceState

## Дальнейшая разработка

Необходимо реализовать:
- [ ] Полную CRUD функциональность для всех таблиц
- [ ] Экран настроек подключения
- [ ] Поиск и фильтрацию данных
- [ ] Экспорт/импорт баз данных
- [ ] Печать документов
- [ ] Работу с DOCX файлами

## Лицензия

Проект является адаптацией оригинального приложения ArchiveFund.
