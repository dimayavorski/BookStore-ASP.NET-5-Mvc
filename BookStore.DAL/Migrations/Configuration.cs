namespace BookStore.DAL.Migrations
{
    using BookStore.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.DAL.EF.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.DAL.EF.BookContext context)
        {
            context.Books.AddOrUpdate(new Book { Id = 1, Name = "Повести Белкина", Description = "В 1830 году Россию захватила вспышка холеры. Дорога к Москве была перекрыта из-за карантина, и Александр Сергеевич Пушкин оказался в вынужденном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 1, CategoryId = 1, Price = 30});
            context.Books.AddOrUpdate(new Book { Id = 2, Name = "Ромео и Джульета", Description = "В 1830 году Россию захватила вспышка холеры. Дорога к Москве была перекрыта из-за карантина, и Александр Сергеевич Пушкин оказался в вынужденном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 1, CategoryId = 1 ,Price = 40});
            context.Books.AddOrUpdate(new Book { Id = 3, Name = "Белый снег", Description = " на обложке, содержит ляссе (ленточку-закладку. Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, possimus a quidem corporis ad impedit, omnis sed eos adipisci fugit et incidunt! Dignissimos autem officia assumenda magnam animi nesciunt laborum sed voluptatum id hic error unde reiciendis nam ipsum beatae, fugiat ea cum nisi ullam laudantium. Delectus assumenda repellendus numquam amet obcaecati atque, beatae harum vero voluptatem, dicta, excepturi est!", AuthorId = 2, CategoryId = 1,Price = 23});
            context.Books.AddOrUpdate(new Book { Id = 4, Name = "Зеленая миля", Description = "том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 3, CategoryId = 2,Price = 43});
            context.Books.AddOrUpdate(new Book { Id = 5, Name = "CLR via C#", Description = "В 1ном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 3, CategoryId = 3, Price = 53});
            context.Books.AddOrUpdate(new Book {  Name = "Евгений Онегин", Description = "В 1830 году Россию захватила вспышка холеры. Дорога к Москве была перекрыта из-за карантина, и Александр Сергеевич Пушкин оказался в вынужденном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 1, CategoryId = 1, Price = 30 });
            context.Books.AddOrUpdate(new Book {  Name = "Паттерный проектирования", Description = "В 1830 году Россию захватила вспышка холеры. Дорога к Москве была перекрыта из-за карантина, и Александр Сергеевич Пушкин оказался в вынужденном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 1, CategoryId = 1, Price = 40 });
            context.Books.AddOrUpdate(new Book {  Name = "Моя кухня", Description = " на обложке, содержит ляссе (ленточку-закладку).Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, possimus a quidem corporis ad impedit, omnis sed eos adipisci fugit et incidunt! Dignissimos autem officia assumenda magnam animi nesciunt laborum sed voluptatum id hic error unde reiciendis nam ipsum beatae, fugiat ea cum nisi ullam laudantium. Delectus assumenda repellendus numquam amet obcaecati atque, beatae harum vero voluptatem, dicta, excepturi est!", AuthorId = 2, CategoryId = 1, Price = 23 });
            context.Books.AddOrUpdate(new Book {  Name = "Умный дом", Description = "том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).",AuthorId = 3,CategoryId = 2, Price = 43 });
            context.Books.AddOrUpdate(new Book {  Name = "Велосипед", Description = "В 1ном затворничестве в имении Большое Болдино. Болдинская осень войдёт в историю как самый продуктивный творческий период писателя. За три месяца он создал около пятидесяти произведений, в том числе и Повести Белкина. Книгу составляют предисловие От издателя и пять повестей: Выстрел, Метель, Гробовщик, Станционный смотритель и Барышня - крестьянка. Издание выполнено с тиснением на обложке, содержит ляссе (ленточку-закладку).", AuthorId = 3, CategoryId = 3, Price = 53 });

            //End Books Initialize

            //Start Authors Initialize
            context.Authors.AddOrUpdate(new Author { Id = 1, Name = "А.С.Пушкин" });
            context.Authors.AddOrUpdate(new Author { Id = 2, Name = "М.С.Тургениев" });
            context.Authors.AddOrUpdate(new Author { Id = 3, Name = "Стивен Кинг" });
            //End Authors Initialize

            //Start Categories Initialize
            context.Categories.AddOrUpdate(new Category { Id = 1, CategoryName = "Классика" });
            context.Categories.AddOrUpdate(new Category { Id = 2, CategoryName = "Фентези" });
            context.Categories.AddOrUpdate(new Category { Id = 3, CategoryName = "Ужасы" });
            context.Categories.AddOrUpdate(new Category { Id = 4, CategoryName = "Драмма" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
