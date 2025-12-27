# Terminal Notes App – TODOs

## Phase 1 – Skeleton
- [x] Create a new .NET console project
- [x] Decide the root notes directory (e.g. ~/.notes)
- [x] Ensure directory structure exists on startup
    - ~/notes/
        0001.md
        0002.md
        trash/
        index.json
- [x] Parse basic CLI arguments (`args[]`)
    - notes add
    - notes open
    - notes list
    - notes delete
- [x] Implement `notes list` command
- [x] Print "no notes yet" when index is empty

**Done when:**  
The app runs, accepts commands, and `notes list` works without errors.

---

## Phase 2 – Notes as Data
- [x] Define `Note` model (Id, Title, Tags, CreatedAt, UpdatedAt, IsDeleted)
- [x] Files get created from the user with a name from the user
    - user says: notes add file1.txt [x]
    - app creates a file with that name [x]
    - app updates index.json file with the metadata of that file [x]
        - metadata is: created_at, saved_at,deleted_at [x]
    - app opens the newly created file in the default terminal editor [x]
- [x] Create `index.json` structure
- [x] Implement loading index from disk
- [x] Implement saving index to disk
- [x] Implement creating a file with tags

**Done when:**  
Notes metadata survives app restarts.

---

## Phase 3 – Create & List Notes
- [x] Implement `notes add "title"` command
- [x] Support optional `--tags a,b,c`
- [x] Add note entry to index
- [x] Auto-generate unique note IDs
- [x] Improve `notes list` output (id, title, date, tags)

**Done when:**  
You can add notes and see them listed.

---

## Phase 4 – Open & Edit Notes
- [x] Detect editor via `EDITOR` env variable
- [x] Fallback to OS default editor
- [x] Implement `notes open <name>`
- [x] Launch editor with note file
- [x] Update `UpdatedAt` after editing

**Done when:**  
You can comfortably use the app daily.

---

## Phase 5 – Search & Tags
- [x] Implement `notes search <text>`
- [x] create notes inside folder using given path
- [x] Implement `notes list --tag <tag>`
- [x] Ignore deleted notes in results
- [x] Use index first before reading files
- [x] Case-insensitive search

**Done when:**  
Finding notes feels fast and useful.

---

## Phase 6 – Delete Safely
- [x] Implement `notes delete <FileName>` (soft delete)
- [x] Move note file to `trash/`
- [x] Mark note as deleted in index
- [x] Implement `notes restore <id>`

**Done when:**  
You are not afraid of losing notes.

---

## Phase 7 – Polish
- [ ] Help command (`notes help`)
- [ ] Write README
- [ ] Add usage examples

**Done when:**  
Project is portfolio-ready.
