# Wiz-Film-Search

An API with a single endpoint. This is a technical test for a job at Wiz soluções.
The endpoint is a GET that return the next movies to be released.



## Usage

There is a postman in the root of the project with some integration tests. Use them to have a easy request for testing.

* Open solution with the .sln file.
* Run as it is. All libs should download automaticaly.
* Open postman file and run the tests as you wish.

## API especification

**Movie API**
----
  Fetch a list of movies

* **URL**

  /api/movie

* **Method:**
  
  `GET` 

* **Headers:**
  
  `api-key : 28236d8ec201df516d0f6472d516d72d` 
  
*  **URL Params**
 
   `numberOfPages=<Integer>`
   
    Default = 1

   This will specify how many pages of information from the api you want to receive. 1 page = 20 results. 3 pages = 60 results.

* **Success Response:**
  
  * **Code:** 200 <br />
    **Content:** `[
    {
        "genreIds": [
            28,
            18,
            36
        ],
        "title": "Ip Man 4: The Finale",
        "voteAverage": 6,
        "overview": "Following the death of his wife, Ip Man travels to San Francisco to ease tensions between the local kung fu masters and his star student, Bruce Lee, while searching for a better future for his son.",
        "releaseDate": "2019-12-20"
    }, ... ]`
 
* **Error Response:**

  * **Code:** 401 UNAUTHORIZED <br />
    **Content:** `Invalid Api Key`

  OR

  * **Code:** 200 BAD REQUEST <br />
    **Content:** `Api Key is missing - Add api-key <yourkey> to the header`

  OR

  * **Code:** 500 INTERNAL ERROR <br />
    **Content:** `There was an error.`

* **Sample Call:**

    Check out the postman_collection.json.

* **Notes:**

    `23/02/2020 Lucas Brilhante`

## License
[MIT](https://choosealicense.com/licenses/mit/)