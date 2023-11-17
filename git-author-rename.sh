git filter-branch -f --env-filter "
    GIT_AUTHOR_NAME='devz097'
    GIT_AUTHOR_EMAIL='rogue_knight_414@hotmail.com'
    GIT_COMMITTER_NAME='devz097'
    GIT_COMMITTER_EMAIL='rogue_knight_414@hotmail.com'
  " HEAD