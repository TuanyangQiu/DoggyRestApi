using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggyRestApi.Migrations
{
    public partial class insert_TestData_TouristRoute_And_TouristRoutePictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureCity", "DepartureTime", "Description", "DiscountPercent", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "Title", "TravelDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("16e5d1ed-2e5a-4ce7-a8da-15bb2c2073c9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Explore the natural wonders of Austria on this 10-day outdoor adventure. Hike through the picturesque landscapes of the Austrian Alps and enjoy breathtaking views. Visit the stunning lakes of the Salzkammergut region and take a refreshing swim in crystal-clear waters. Experience the thrill of white-water rafting in the Tirol region. Immerse yourself in the beauty of Austria's national parks and create lasting memories in the heart of nature.", 0.20000000000000001, "Hiking and outdoor activities, Accommodation in mountain lodges, Transportation within Austria", "Equipment rental included, Meals included", "Airfare not included, Valid passport required", 17800.0m, 5.0, "Outdoor Escapes - Austrian Alps, Salzkammergut", 10, 3, null },
                    { new Guid("21b8cbe0-05b7-43c5-941e-4a874e2b7bc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Experience the beauty of Austria's lakes and mountains on this 9-day scenic tour. Begin your journey in Vienna and explore its architectural wonders. Visit the charming town of Zell am See and enjoy panoramic views of Lake Zell and the surrounding Alps. Discover the beauty of the Grossglockner High Alpine Road and hike through pristine alpine landscapes. Immerse yourself in Austrian culture and indulge in delicious local cuisine.", 0.10000000000000001, "Sightseeing tours, Accommodation in lakeside resorts, Transportation within Austria", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 16800.0m, 5.0, "Lakes and Mountains Discovery - Vienna, Zell am See", 9, 3, null },
                    { new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Embark on a culinary journey through Austria on this 7-day food and wine tour. Begin your adventure in Vienna and indulge in traditional Viennese cuisine. Explore the vineyards of the Wachau Valley and savor exquisite wines. Discover the culinary delights of Graz and enjoy a cooking class to learn the secrets of Austrian cuisine. Immerse yourself in the flavors of Austria and experience a gastronomic adventure like no other.", 0.14999999999999999, "Food and wine tastings, Accommodation in gourmet hotels, Transportation within Austria", "Meals included, Personal expenses not included", "Airfare not included, Valid passport required", 14500.0m, 5.0, "Taste of Austria - Vienna, Wachau Valley, Graz", 7, 2, null },
                    { new Guid("3010192b-0035-4ef7-8bc5-b81d5dc103a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Embark on an unforgettable 8-day journey through the breathtaking landscapes of the South Island of New Zealand. Begin your adventure in Christchurch and explore its vibrant art scene. Visit the stunning Lake Tekapo and witness its turquoise waters. Journey through the majestic Southern Alps and marvel at the beauty of Aoraki/Mount Cook. Experience the thrill of glacier hiking in Franz Josef and explore the pristine fjords of Milford Sound. This tour offers a perfect blend of adventure and natural beauty.", 0.10000000000000001, "Sightseeing tours, Accommodation in wilderness lodges, Transportation within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 15600.0m, 5.0, "South Island Expedition - Christchurch, Franz Josef, Milford Sound", 8, 3, null },
                    { new Guid("4d65c663-8e08-4b48-8e94-8b5a5ac62eaa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Experience the best of New Zealand's wine regions on this 7-day tour. Visit the renowned wineries of Marlborough and taste exquisite Sauvignon Blanc. Explore the picturesque vineyards of Hawke's Bay and indulge in award-winning wines. Immerse yourself in the art of winemaking and learn from expert vintners. This tour offers a perfect blend of wine tasting, gourmet cuisine, and breathtaking landscapes.", 0.14999999999999999, "Wine tastings, Accommodation in vineyard estates, Transportation within New Zealand", "Wine tasting fees included, Meals included", "Airfare not included, Valid passport required", 13200.0m, 5.0, "Wine Lover's Delight - Marlborough, Hawke's Bay", 7, 2, null },
                    { new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour. Explore the charming city of Salzburg and visit the iconic locations from the 'Sound of Music'. Experience the serenity of Lake Wolfgang and take a boat ride across its crystal-clear waters. Discover the stunning landscapes of the Austrian Alps and enjoy thrilling outdoor activities. Indulge in delicious Austrian cuisine and create lifelong memories on this unforgettable journey.", 0.14999999999999999, "Guided tours, Accommodation in lakeside hotels, Transportation within Austria", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 13200.0m, 4.0, "Lakes and Mountains - Salzburg, Lake Wolfgang", 6, 2, null },
                    { new Guid("5f0a9de3-3a5f-41e7-ae03-57d24b925b45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Embark on a 12-day grand tour of New Zealand and experience the country's diverse landscapes and cultural heritage. Journey from the North Island to the South Island, visiting iconic destinations such as Auckland, Rotorua, Wellington, Christchurch, Queenstown, and more. Immerse yourself in Maori culture, explore stunning national parks, and indulge in thrilling adventure activities. This comprehensive tour offers a complete New Zealand experience.", 0.20000000000000001, "Comprehensive guided tour, Accommodation in premium hotels, Domestic flights within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 21500.0m, 5.0, "Grand New Zealand Adventure - North Island, South Island", 12, 4, null },
                    { new Guid("6e5e8533-9e02-40e7-b6f3-3ee549d64301"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Experience the beauty of Austria on this 5-day tour. Explore the historic city of Vienna and its magnificent palaces. Visit the charming town of Hallstatt and marvel at its picturesque landscapes. Discover the cultural treasures of Salzburg, birthplace of Mozart. Enjoy traditional Austrian cuisine and immerse yourself in the rich history and culture of this enchanting country.", 0.20000000000000001, "Guided tours, Accommodation in boutique hotels, Transportation within Austria", "Entrance fees to attractions, Meals not included", "Airfare not included, Valid passport required", 9200.0m, 4.0, "Austrian Discovery - Vienna, Hallstatt, Salzburg", 5, 2, null },
                    { new Guid("76870d56-35a9-4b26-84da-f36d2d1b6d5c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Embark on a 10-day adventure through the stunning landscapes of New Zealand. Begin your journey in Auckland and explore its iconic landmarks. Visit the cultural hub of Wellington and discover its vibrant arts scene. Journey through the breathtaking landscapes of the South Island and marvel at the beauty of Fiordland National Park. Immerse yourself in New Zealand's natural wonders and create lifelong memories on this unforgettable tour.", 0.20000000000000001, "Guided tours, Accommodation in luxury resorts, Domestic flights within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 17800.0m, 5.0, "New Zealand Highlights - Auckland, Wellington, South Island", 10, 4, null },
                    { new Guid("7c9a105f-777e-4ed5-93c1-4d26c246d4c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Embark on an unforgettable 8-day adventure through Austria's scenic landscapes. Begin your journey in Vienna, known for its grand architecture and cultural heritage. Explore the Alpine region of Tyrol and experience the charm of Innsbruck. Discover the beauty of the Wachau Valley and enjoy wine tasting in the vineyards. Immerse yourself in Austrian traditions and create lasting memories on this remarkable tour.", 0.10000000000000001, "Sightseeing tours, Accommodation in mountain resorts, Transportation within Austria", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 15600.0m, 5.0, "Alpine Escape - Vienna, Tyrol, Innsbruck", 8, 3, null },
                    { new Guid("8878af46-5bb1-4d19-9a8d-3d0b4f091bcf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Explore the stunning landscapes of New Zealand's South Island on this 8-day adventure. Begin your journey in Christchurch and discover its vibrant arts scene. Visit the majestic Aoraki/Mount Cook and witness its snow-capped peaks. Journey through the breathtaking Fiordland National Park and cruise through the iconic Milford Sound. Immerse yourself in the natural beauty of New Zealand and experience a true outdoor adventure.", 0.10000000000000001, "Sightseeing tours, Accommodation in wilderness lodges, Transportation within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 16800.0m, 4.0, "South Island Discovery - Christchurch, Mount Cook, Milford Sound", 8, 3, null },
                    { new Guid("a12d92a5-4fc6-4d0d-bc94-6f30762c0a52"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Discover the wonders of New Zealand on this 7-day adventure. Begin your journey in Auckland and explore its vibrant cityscape. Visit the geothermal wonders of Rotorua and immerse yourself in Maori culture. Journey through the stunning landscapes of the South Island and witness the beauty of Milford Sound. Experience thrilling activities such as bungee jumping and skydiving in Queenstown. This tour offers an unforgettable exploration of New Zealand's natural wonders.", 0.14999999999999999, "Sightseeing tours, Accommodation in 4-star hotels, Transportation between cities", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 14500.0m, 4.0, "New Zealand Explorer - Auckland, Rotorua, Queenstown", 7, 3, null },
                    { new Guid("a9e6e77e-f971-446b-9a23-09d23c722be2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Discover the best of Austria in 9 unforgettable days. Begin your journey in Vienna and visit its iconic landmarks. Explore the beautiful city of Graz and admire its medieval architecture. Immerse yourself in the cultural heritage of Salzburg and enjoy the stunning views of the Salzkammergut region. Indulge in wine tasting in the Wachau Valley and experience the charm of Austria's countryside. This tour offers a perfect blend of history, culture, and natural beauty.", 0.20000000000000001, "Sightseeing tours, Accommodation in 4-star hotels, Transportation within Austria", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 19500.0m, 5.0, "Best of Austria - Vienna, Graz, Salzburg", 9, 4, null },
                    { new Guid("ae079869-6b29-4987-a34f-6814a4b47b3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Embark on a 5-day journey through the stunning landscapes of the North Island of New Zealand. Begin your adventure in Wellington and discover the capital city's cultural attractions. Visit the geothermal wonderland of Rotorua and experience the thrill of Maori performances. Explore the picturesque town of Taupo and witness the beauty of Huka Falls. Immerse yourself in New Zealand's natural wonders and create lasting memories on this compact yet unforgettable tour.", 0.10000000000000001, "Sightseeing tours, Accommodation in city center hotels, Transportation within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 9600.0m, 4.0, "North Island Discovery - Wellington, Rotorua, Taupo", 5, 2, null },
                    { new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Experience the charm of Austria's Christmas markets on this 3-day festive tour. Visit the enchanting markets in Vienna and stroll through the beautifully decorated stalls. Immerse yourself in the magical atmosphere and taste traditional holiday treats. Explore the historic city of Salzburg and its famous Christmas market. Indulge in mulled wine and gingerbread cookies as you soak up the holiday spirit in Austria.", 0.10000000000000001, "Christmas market visits, Accommodation in city center hotels, Transportation within Austria", "Meals not included", "Airfare not included, Valid passport required", 6200.0m, 4.0, "Austrian Christmas Markets - Vienna, Salzburg", 3, 1, null },
                    { new Guid("e0f319a1-0f20-45e0-938f-527ac77dddb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Experience the beauty of New Zealand's North Island on this 6-day cultural tour. Begin your journey in Auckland and discover its Maori heritage. Visit the thermal wonderland of Rotorua and learn about traditional Maori arts and crafts. Explore the stunning landscapes of the Bay of Islands and cruise through its pristine waters. Immerse yourself in the rich Maori culture and create lasting memories on this immersive cultural adventure.", 0.10000000000000001, "Cultural experiences, Accommodation in Maori-inspired lodges, Transportation within New Zealand", "Entrance fees to attractions, Meals included", "Airfare not included, Valid passport required", 13200.0m, 4.0, "Maori Discovery - Auckland, Rotorua, Bay of Islands", 6, 2, null },
                    { new Guid("e9561271-5fcd-498f-86f4-bd2598ea9ec8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Experience the magic of the Austrian Alps on this 4-day winter adventure. Explore the world-renowned ski resorts of Innsbruck and enjoy thrilling winter sports activities. Discover the beauty of the Stubai Glacier and indulge in panoramic views of the surrounding mountains. Immerse yourself in Austrian hospitality and warm up with traditional alpine cuisine. This tour is perfect for snow enthusiasts and nature lovers alike.", 0.10000000000000001, "Skiing and snowboarding, Accommodation in alpine lodges, Transportation within Austria", "Ski pass, Equipment rental included", "Airfare not included, Valid passport required", 8500.0m, 4.0, "Alpine Winter Wonderland - Innsbruck, Stubai Glacier", 4, 1, null },
                    { new Guid("f08cdd81-7c88-4a12-9099-783b3af05f95"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Discover the hidden gems of Austria on this 6-day off-the-beaten-path tour. Explore the charming village of Hallstatt and its breathtaking lakeside scenery. Visit the historical city of Graz and wander through its cobblestone streets. Discover the fairy-tale landscapes of the Salzkammergut region and enjoy leisurely boat rides. Immerse yourself in the authentic Austrian culture and experience the true essence of this captivating country.", 0.14999999999999999, "Guided tours, Accommodation in charming guesthouses, Transportation within Austria", "Entrance fees to attractions, Meals not included", "Airfare not included, Valid passport required", 13500.0m, 4.0, "Hidden Austria - Hallstatt, Graz, Salzkammergut", 6, 2, null },
                    { new Guid("f3821f4a-86b2-4d02-aefb-9e53f86b1dc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Discover the natural wonders of New Zealand on this 9-day outdoor adventure. Explore the rugged landscapes of the North Island and witness the power of geothermal activity in Rotorua. Journey to the South Island and hike through the breathtaking Southern Alps. Experience the thrill of bungee jumping in Queenstown and kayak in the pristine waters of Abel Tasman National Park. Immerse yourself in the beauty of New Zealand's nature and create lifelong memories on this adrenaline-filled tour.", 0.20000000000000001, "Outdoor activities, Accommodation in adventure lodges, Transportation within New Zealand", "Equipment rental included, Meals included", "Airfare not included, Valid passport required", 19500.0m, 5.0, "Outdoor Thrills - Rotorua, Queenstown, Abel Tasman", 9, 3, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutePictures",
                columns: new[] { "Id", "TouristRouteId", "Url" },
                values: new object[,]
                {
                    { 1, new Guid("6e5e8533-9e02-40e7-b6f3-3ee549d64301"), "Sydney_12345.jpg" },
                    { 2, new Guid("6e5e8533-9e02-40e7-b6f3-3ee549d64301"), "Melbourne_67890.jpg" },
                    { 3, new Guid("6e5e8533-9e02-40e7-b6f3-3ee549d64301"), "Brisbane_23456.jpg" },
                    { 4, new Guid("7c9a105f-777e-4ed5-93c1-4d26c246d4c5"), "Perth_34567.jpg" },
                    { 5, new Guid("7c9a105f-777e-4ed5-93c1-4d26c246d4c5"), "Adelaide_78901.jpg" },
                    { 6, new Guid("7c9a105f-777e-4ed5-93c1-4d26c246d4c5"), "Auckland_45678.jpg" },
                    { 7, new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), "Wellington_90123.jpg" },
                    { 8, new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), "Christchurch_56789.jpg" },
                    { 9, new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), "GoldCoast_23456.jpg" },
                    { 10, new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), "Cairns_78901.jpg" },
                    { 11, new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"), "Queenstown_34567.jpg" },
                    { 12, new Guid("a9e6e77e-f971-446b-9a23-09d23c722be2"), "Rotorua_89012.jpg" },
                    { 13, new Guid("a9e6e77e-f971-446b-9a23-09d23c722be2"), "SydneyOperaHouse_56789.jpg" },
                    { 14, new Guid("a9e6e77e-f971-446b-9a23-09d23c722be2"), "GreatBarrierReef_23456.jpg" },
                    { 15, new Guid("e9561271-5fcd-498f-86f4-bd2598ea9ec8"), "AyersRock_78901.jpg" },
                    { 16, new Guid("e9561271-5fcd-498f-86f4-bd2598ea9ec8"), "SydneyHarbourBridge_89012.jpg" },
                    { 17, new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"), "Hamilton_45678.jpg" },
                    { 18, new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"), "Dunedin_12345.jpg" },
                    { 19, new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"), "MelbourneMuseum_67890.jpg" },
                    { 20, new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"), "BlueMountains_23456.jpg" },
                    { 21, new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"), "SurfersParadise_78901.jpg" },
                    { 22, new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"), "AucklandSkyTower_56789.jpg" },
                    { 23, new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"), "QueenstownGardens_23456.jpg" },
                    { 24, new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"), "GreatOceanRoad_78901.jpg" },
                    { 25, new Guid("16e5d1ed-2e5a-4ce7-a8da-15bb2c2073c9"), "WellingtonBotanicGarden_89012.jpg" },
                    { 26, new Guid("16e5d1ed-2e5a-4ce7-a8da-15bb2c2073c9"), "SydneyHarbour_45678.jpg" },
                    { 27, new Guid("f08cdd81-7c88-4a12-9099-783b3af05f95"), "BondiBeach_12345.jpg" },
                    { 28, new Guid("f08cdd81-7c88-4a12-9099-783b3af05f95"), "BrisbaneCityHall_67890.jpg" },
                    { 29, new Guid("f08cdd81-7c88-4a12-9099-783b3af05f95"), "MelbourneZoo_23456.jpg" },
                    { 30, new Guid("21b8cbe0-05b7-43c5-941e-4a874e2b7bc0"), "MilfordSound_78901.jpg" },
                    { 31, new Guid("21b8cbe0-05b7-43c5-941e-4a874e2b7bc0"), "FranzJosefGlacier_89012.jpg" },
                    { 32, new Guid("a12d92a5-4fc6-4d0d-bc94-6f30762c0a52"), "AdelaideBotanicGarden_56789.jpg" },
                    { 33, new Guid("a12d92a5-4fc6-4d0d-bc94-6f30762c0a52"), "UluruKataTjutaNationalPark_23456.jpg" },
                    { 34, new Guid("76870d56-35a9-4b26-84da-f36d2d1b6d5c"), "KangarooIsland_78901.jpg" },
                    { 35, new Guid("76870d56-35a9-4b26-84da-f36d2d1b6d5c"), "AucklandWarMemorialMuseum_56789.jpg" },
                    { 36, new Guid("76870d56-35a9-4b26-84da-f36d2d1b6d5c"), "TePapaMuseum_23456.jpg" },
                    { 37, new Guid("e0f319a1-0f20-45e0-938f-527ac77dddb5"), "YarraRiver_78901.jpg" },
                    { 38, new Guid("e0f319a1-0f20-45e0-938f-527ac77dddb5"), "GreatBarrierReefMarinePark_89012.jpg" },
                    { 39, new Guid("e0f319a1-0f20-45e0-938f-527ac77dddb5"), "SydneyTowerEye_45678.jpg" },
                    { 40, new Guid("3010192b-0035-4ef7-8bc5-b81d5dc103a0"), "QueenVictoriaMarket_12345.jpg" },
                    { 41, new Guid("3010192b-0035-4ef7-8bc5-b81d5dc103a0"), "SydneyFishMarket_67890.jpg" },
                    { 42, new Guid("3010192b-0035-4ef7-8bc5-b81d5dc103a0"), "HobbitonMovieSet_23456.jpg" }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutePictures",
                columns: new[] { "Id", "TouristRouteId", "Url" },
                values: new object[,]
                {
                    { 43, new Guid("f3821f4a-86b2-4d02-aefb-9e53f86b1dc0"), "SydneyRoyalBotanicGarden_78901.jpg" },
                    { 44, new Guid("f3821f4a-86b2-4d02-aefb-9e53f86b1dc0"), "MelbourneRoyalBotanicGardens_45678.jpg" },
                    { 45, new Guid("f3821f4a-86b2-4d02-aefb-9e53f86b1dc0"), "SydneyCove_12345.jpg" },
                    { 46, new Guid("ae079869-6b29-4987-a34f-6814a4b47b3d"), "MountCook_67890.jpg" },
                    { 47, new Guid("ae079869-6b29-4987-a34f-6814a4b47b3d"), "SydneyAquarium_23456.jpg" },
                    { 48, new Guid("4d65c663-8e08-4b48-8e94-8b5a5ac62eaa"), "WellingtonWaterfront_78901.jpg" },
                    { 49, new Guid("4d65c663-8e08-4b48-8e94-8b5a5ac62eaa"), "ChristchurchBotanicGardens_89012.jpg" },
                    { 50, new Guid("5f0a9de3-3a5f-41e7-ae03-57d24b925b45"), "GreatBarrierReefDiving_56789.jpg" },
                    { 51, new Guid("5f0a9de3-3a5f-41e7-ae03-57d24b925b45"), "LakeTaupo_23456.jpg" },
                    { 52, new Guid("8878af46-5bb1-4d19-9a8d-3d0b4f091bcf"), "FoxGlacier_78901.jpg" },
                    { 53, new Guid("8878af46-5bb1-4d19-9a8d-3d0b4f091bcf"), "SydneyOperaHouseAtNight_89012.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("16e5d1ed-2e5a-4ce7-a8da-15bb2c2073c9"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("21b8cbe0-05b7-43c5-941e-4a874e2b7bc0"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("22f6d1f4-ff26-429f-b7c2-bab8a6624e6f"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("3010192b-0035-4ef7-8bc5-b81d5dc103a0"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("4d65c663-8e08-4b48-8e94-8b5a5ac62eaa"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("5342e7fe-3b03-495f-9b4c-08fcfa1ea4fb"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("5f0a9de3-3a5f-41e7-ae03-57d24b925b45"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("6e5e8533-9e02-40e7-b6f3-3ee549d64301"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("76870d56-35a9-4b26-84da-f36d2d1b6d5c"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("7c9a105f-777e-4ed5-93c1-4d26c246d4c5"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("8878af46-5bb1-4d19-9a8d-3d0b4f091bcf"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("a12d92a5-4fc6-4d0d-bc94-6f30762c0a52"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("a9e6e77e-f971-446b-9a23-09d23c722be2"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("ae079869-6b29-4987-a34f-6814a4b47b3d"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("d685b277-2e33-421f-9eab-26d7d8e6fe2e"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("e0f319a1-0f20-45e0-938f-527ac77dddb5"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("e9561271-5fcd-498f-86f4-bd2598ea9ec8"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("f08cdd81-7c88-4a12-9099-783b3af05f95"));

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("f3821f4a-86b2-4d02-aefb-9e53f86b1dc0"));
        }
    }
}
