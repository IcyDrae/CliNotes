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
- [ ] Define `Note` model (Id, Title, Tags, CreatedAt, UpdatedAt, IsDeleted)
- [ ] Decide file naming scheme (e.g. `0001.md`)
- [ ] Create `index.json` structure
- [ ] Implement loading index from disk
- [ ] Implement saving index to disk
- [ ] Handle missing or corrupted index gracefully

**Done when:**  
Notes metadata survives app restarts.

---

## Phase 3 – Create & List Notes
- [ ] Implement `notes add "title"` command
- [ ] Support optional `--tags a,b,c`
- [ ] Create note file with initial content
- [ ] Add note entry to index
- [ ] Auto-generate unique note IDs
- [ ] Improve `notes list` output (id, title, date, tags)

**Done when:**  
You can add notes and see them listed.

---

## Phase 4 – Open & Edit Notes
- [ ] Detect editor via `EDITOR` env variable
- [ ] Fallback to OS default editor
- [ ] Implement `notes open <id>`
- [ ] Launch editor with note file
- [ ] Update `UpdatedAt` after editing
- [ ] Handle invalid IDs cleanly

**Done when:**  
You can comfortably use the app daily.

---

## Phase 5 – Search & Tags
- [ ] Implement `notes search <text>`
- [ ] Implement `notes list --tag <tag>`
- [ ] Ignore deleted notes in results
- [ ] Use index first before reading files
- [ ] Case-insensitive search

**Done when:**  
Finding notes feels fast and useful.

---

## Phase 6 – Delete Safely
- [ ] Implement `notes delete <id>` (soft delete)
- [ ] Move note file to `trash/`
- [ ] Mark note as deleted in index
- [ ] Implement `notes restore <id>`
- [ ] Prevent duplicate deletes/restores

**Done when:**  
You are not afraid of losing notes.

---

## Phase 7 – Polish
- [ ] Clear error messages
- [ ] Consistent command output format
- [ ] Help command (`notes help`)
- [ ] Write README
- [ ] Add usage examples
- [ ] Small refactors and cleanup

**Done when:**  
Project is portfolio-ready.
