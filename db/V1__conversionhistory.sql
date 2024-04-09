create table conversion
(
    id serial primary key,
    sourcecurrency  varchar(3),
    targetcurrency  varchar(3),
    amount          integer,
    convertedamount numeric(18, 2),
    timestamp       timestamp
);
