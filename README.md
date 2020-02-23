# Wiz-Film-Search

An API with a single endpoint. This is a technical test for a job at Wiz soluções.
The endpoint is a GET that return the next movies to be released.



## Usage

There is a postman in the root of the project with some integration tests. Use them to have a easy request for testing.

* Open solution with the .sln file.
* Run as it is. All libs should download automaticaly.
* Open postman file and run the tests as you wish.

## Architecture

**External libs**

    <PackageReference Include="refit" Version="5.0.23" />
    <PackageReference Include="Refit.HttpClientFactory" Version="5.0.23" />

Refit was a decision over the manual HttpClientFactory for a lot of reasons.

 1 it makes the service a lot easier to test, allowing us to mock the request and test the service code alone. 
 
 2 Makes the code much cleaner, not having to worry about json parse (it is strongly typed) or the request setup.

 3 Makes it easy to add more apis access with no problem. Also maintain the external endpoints in a clean place.

    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.2.0" />
    <PackageReference Include="Moq" Version="4.13.1" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.0.0" />
    <PackageReference Include="MSTest.TestFramework" Version="2.0.0" />
    <PackageReference Include="coverlet.collector" Version="1.0.1" />

Mostly usual test stuff. Moq is used for mocking the DI objects and allowing unit testing.

**Architecture choices**
I decided for a `service oriented architechture` because this service would be simple and I imagined it as a microservice with no SQL database. This would make that the data model would not be sensible and probably usable by one of our mobile application. DDD and other architechtures would make it much more complex than it needs to be.

Said that, I decided to make some displays of what I would add in a full application.

1. The Url and Aplication Key are in the appsettings.json. This makes possible to hide this variables in the future adding them in the environment variables of the `deploy environment`. This also would make possible to change this variables depending on the environment (like dev, int, prod).

2. `Dependency injection` is a important concept that I decided to add to make possible mocked tests and also use the appsetting.json variables. This also made possible to use `Refit`, making the external calls a mockable service.

3. I added `mocked tests` using moq and DI to make clear what tests would look like. Usually we see trivial model tests and I decided to add some exemples of the more complex ones.

4. I also decided to add a `middleware api-key checker` to display more different skills. TokenRepoService has a mock to check the keys, since it was not part of the challange to check a external service for the key. But the idea is to not have any hardcoded keys. Also this is a authentication key, allowing access. An Authorization key could be added with a login giving a key to a specific users.

5. All services have a Interface. This allows the DI and also the mock for tests.

**Things I would like to add**

* Swagger as a good api specification

* Dockerfile with the build.

* Jenkinsfile with CI and Gitflow, allowing deploy in certain branchs.

* Full unit test coverage

* Middleware for error haddling (avoinding try catch all over the code)

* Logging system (with application insights for instance)

## API specification

**Movie API**

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