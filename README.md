
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


## Obs
- Poderia ter usado Mongodb para persistência, maaas :woman_shrugging:
- Nem o ~camisa de tactel~ conseguiu me ajudar a resolver o erro `The remote certificate was rejected by the provided` executando tudo no container. Se rolar esse xabu, sorry guys
