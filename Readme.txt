This is a webAPI which was made by ASP.Net Core.

I created an end point of /Order

The test request could be:
{
  "poId": 3344656,
  "customerId": 4567890 ,
  "total": 48.50,
  "itemLines": [
    "Video 'Comprehensive First Aid Training'",
    "Book 'The Girl on the train'",
    "Book Club Membership"
  ]
}

In order to show the logic and method, I ignored the operation details of database.