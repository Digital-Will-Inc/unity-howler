# Changelog

## [1.0.4] - 2023-09-15
### Fixed
- Payload options not being applied

## [1.0.3] - 2023-09-05
### Added
- StopAll method to stop all sounds and unload them from memory

### Fixed
- Sounds are now garbage collected after finishing or being stopped

## [1.0.2] - 2023-08-22
### Fixed
- InitializeHowler is no longer called in the editor

## [1.0.1] - 2023-08-22
### Fixed
- Fixed a bug where the `Howler.OnInitialized` event would fire but `Howler.IsInitialized` would still be false.


## [1.0.0] - 2023-08-21
- Initial release
