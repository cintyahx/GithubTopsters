
# BotiGitHubTest

Desafio do teste técnico para Dev Backend .Net


## Requisitos

- Docker
- Docker-compose
- SDK .Net Core 6.0


## Execução

Execute o arquivo [docker-compose.yml](https://github.com/cintyahx/GithubTopsters/blob/main/docker-compose.yml) com `docker-compose`

```bash
  docker-compose up
```
    

## Endpoints

`/api/Github/list-default`
- Utiliza valores default para a consulta:
  - Linguagens: `C#`, `Vue`, `TypeScript`, `JavaScript`, `Python`
  - Quantitade: 3

`/api/Github/list`
- Utiliza valores informados para a consulta:
  - languages: `List<string>`
  - quantity: `int`
